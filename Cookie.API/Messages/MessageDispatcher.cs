using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Cookie.API.Core;
using Cookie.API.Protocol;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;

namespace Cookie.API.Messages
{
    /// <summary>
    ///     Classic message dispatcher
    /// </summary>
    /// <typeparam name="T">Messsage dispatcher type</typeparam>
    public class MessageDispatcher
    {
        private readonly Dictionary<string, Dictionary<Type, List<MessageHandler>>> _handlers =
            new Dictionary<string, Dictionary<Type, List<MessageHandler>>>();

        private readonly ManualResetEventSlim _messageEnqueuedEvent = new ManualResetEventSlim(false);

        private readonly SortedDictionary<MessagePriority, Queue<Tuple<Message, object>>> _messagesToDispatch =
            new SortedDictionary<MessagePriority, Queue<Tuple<Message, object>>>();

        private readonly ManualResetEventSlim _resumeEvent = new ManualResetEventSlim(true);

        private int _currentThreadId;
        private bool _dispatching;

        private Stopwatch _spy;

        public MessageDispatcher()
        {
            foreach (var value in Enum.GetValues(typeof(MessagePriority)))
                _messagesToDispatch.Add((MessagePriority) value, new Queue<Tuple<Message, object>>());
        }

        public object CurrentProcessor { get; private set; }

        public int CurrentThreadId => _currentThreadId;

        public bool Stopped { get; private set; }

        /// <summary>
        ///     Says how many milliseconds elapsed since last message.
        /// </summary>
        public long DelayFromLastMessage
        {
            get
            {
                if (_spy == null) _spy = Stopwatch.StartNew();
                return _spy.ElapsedMilliseconds;
            }
        }

        public event Action<MessageDispatcher, Message> MessageDispatched;

        protected void OnMessageDispatched(Message message)
        {
            var evnt = MessageDispatched;
            if (evnt != null)
                MessageDispatched?.Invoke(this, message);
        }

        public void Enqueue(Message message, bool executeIfCan = true)
        {
            Enqueue(message, null, executeIfCan);
        }

        public virtual void Enqueue(Message message, object token, bool executeIfCan = true)
        {
            if (executeIfCan && IsInDispatchingContext())
                Dispatch(message, token);
            else
                lock (_messageEnqueuedEvent)
                {
                    _messagesToDispatch[message.Priority].Enqueue(Tuple.Create(message, token));

                    if (!_dispatching)
                        _messageEnqueuedEvent.Set();
                }
        }

        public bool IsInDispatchingContext()
        {
            return Thread.CurrentThread.ManagedThreadId == _currentThreadId &&
                   CurrentProcessor != null;
        }

        public void RegisterMessageHandler<T>(string callingPlugin, Type t, Action<IAccount, T> handler,
            MessagePriority priority) where T : Message
        {
            if (!_handlers.ContainsKey(callingPlugin))
                _handlers.Add(callingPlugin, new Dictionary<Type, List<MessageHandler>>());

            if (!_handlers[callingPlugin].ContainsKey(t))
                _handlers[callingPlugin].Add(t, new List<MessageHandler>());

            _handlers[callingPlugin][t].Add(new MessageHandler(t, Convert(handler), callingPlugin,
                handler.Method.GetParameters()[0].ParameterType, priority));
        }

        public Action<IAccount, object> Convert<T>(Action<IAccount, T> myActionT)
        {
            return myActionT == null ? (Action<IAccount, object>) null : ((a, o) => myActionT(a, (T) o));
        }

        public void ProcessDispatching(object processor)
        {
            if (Stopped)
                return;

            if (Interlocked.CompareExchange(ref _currentThreadId, Thread.CurrentThread.ManagedThreadId, 0) == 0)
            {
                CurrentProcessor = processor;
                _dispatching = true;

                var copy = _messagesToDispatch.ToArray();
                foreach (var keyPair in copy)
                {
                    if (Stopped)
                        break;

                    while (keyPair.Value.Count != 0)
                    {
                        if (Stopped)
                            break;

                        var message = keyPair.Value.Dequeue();

                        if (message != null)
                            Dispatch(message.Item1, message.Item2);
                    }
                }

                CurrentProcessor = null;
                _dispatching = false;
                Interlocked.Exchange(ref _currentThreadId, 0);
            }

            lock (_messagesToDispatch)
            {
                if (_messagesToDispatch.Sum(x => x.Value.Count) > 0)
                    _messageEnqueuedEvent.Set();
                else
                    _messageEnqueuedEvent.Reset();
            }
        }

        public void Remove(string pluginName)
        {
            _handlers.Remove(pluginName);
        }

        protected virtual void Dispatch(Message message, object token)
        {
            foreach (var handler in GetHandlers(message.GetType(), token).ToArray()
            ) // have to transform it into a collection if we want to add/remove handler
            {
                try
                {
                    handler.Handler.Invoke((IAccount) token, message);
                }
                catch (Exception ex)
                {
                    Logger.Default.Log($"Cannot dispatch {message}", LogMessageType.Public);
                    Console.WriteLine(ex);
                }
                if (message.Canceled)
                    break;
            }

            message.OnDispatched();
            OnMessageDispatched(message);
        }

        protected IEnumerable<MessageHandler> GetHandlers(Type messageType, object token)
        {
            var handlersEnumerable = new List<MessageHandler>();

            foreach (var list in _handlers.Values.ToList()
            ) // ToArray : to avoid error if handler are added in the same time
            {
                List<MessageHandler> handlersList;

                if (list.TryGetValue(typeof(NetworkMessage), out handlersList))
                    foreach (var handler in handlersList)
                        if (token == null || handler.TokenType.IsInstanceOfType(token))
                            handlersEnumerable.Add(handler);

                if (list.TryGetValue(messageType, out handlersList))
                    foreach (var handler in handlersList)
                        if (token == null || handler.TokenType.IsInstanceOfType(token))
                            handlersEnumerable.Add(handler);
            }

            return handlersEnumerable;

            // note : disabled yet.

            // recursivity to handle message from base class
            //if (messageType.BaseType != null && messageType.BaseType.IsSubclassOf(typeof(Message)))
            //    foreach (var handler in GetHandlers(messageType.BaseType, token))
            //    {
            //        if (handler.Attribute.HandleChildMessages)
            //            yield return handler;
            //    }
        }

        /// <summary>
        ///     Block the current thread until a message is enqueued
        /// </summary>
        public void Wait()
        {
            if (Stopped)
                _resumeEvent.Wait();

            if (_messagesToDispatch.Sum(x => x.Value.Count) > 0)
                return;

            _messageEnqueuedEvent.Wait();
        }

        public void Resume()
        {
            if (!Stopped)
                return;

            Stopped = false;
            _resumeEvent.Set();
        }

        public void Stop()
        {
            if (Stopped)
                return;

            Stopped = true;
            _resumeEvent.Reset();
        }

        public void Dispose()
        {
            Stop();

            foreach (var messages in _messagesToDispatch)
                messages.Value.Clear();
        }

        /// <summary>
        ///     Reset timer for last received message
        /// </summary>
        protected void ActivityUpdate()
        {
            if (_spy == null)
                _spy = Stopwatch.StartNew();
            else
                _spy.Restart();
        }
    }
}