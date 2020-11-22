using System;
using System.Threading;

namespace Cookie.API.Messages
{
    [Serializable]
    public abstract class Message
    {
        protected Message()
        {
            Priority = MessagePriority.Normal;
        }

        public bool Canceled { get; set; }

        public MessagePriority Priority { get; set; }

        public bool IsDispatched { get; private set; }
        public event Action<Message> Dispatched;

        public virtual void BlockProgression()
        {
            Canceled = true;
        }

        /// <summary>
        ///     Internal use only
        /// </summary>
        public void OnDispatched()
        {
            if (IsDispatched)
                return;

            lock (this)
            {
                Monitor.PulseAll(this);
            }

            IsDispatched = true;

            var evnt = Dispatched;
            evnt?.Invoke(this);
        }

        /// <summary>
        ///     Block the current thread until the message is dispatched
        /// </summary>
        /// <returns>false whenever the message has already been dispatched</returns>
        public bool Wait()
        {
            return Wait(TimeSpan.Zero);
        }

        /// <summary>
        ///     Block the current thread until the message is dispatched
        /// </summary>
        /// <param name="timeout"></param>
        /// <returns>false whenever the message has already been dispatched</returns>
        public bool Wait(TimeSpan timeout)
        {
            if (IsDispatched)
                return false;

            lock (this)
            {
                if (timeout > TimeSpan.Zero)
                    Monitor.Wait(this, timeout);
                else
                    Monitor.Wait(this);
            }

            return true;
        }
    }
}