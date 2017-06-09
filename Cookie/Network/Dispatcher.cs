using Cookie.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Cookie
{
    public class Dispatcher
    {
        #region Var
        private Dictionary<uint, MethodHandler> methods;
        private Queue<NetworkMessage> msgQueue;
        private Task executionTask;
        private TimerCore timer;
        private DofusClient client;
        #endregion

        #region Constructor
        public Dispatcher(DofusClient client)
        {
            this.client = client;
            methods = new Dictionary<uint, MethodHandler>();
            msgQueue = new Queue<NetworkMessage>();
            timer = new TimerCore(new Action(Execute), 50, 50);
        }
        #endregion

        #region Private Methods
        private void Execute()
        {
            if ((executionTask != null && !executionTask.IsCompleted) || msgQueue.Count <= 0)
                return; 
            var actualMessage = msgQueue.Dequeue();

            if (client.Debug)
                client.Logger.Log($"Received: ({actualMessage.MessageID}) - " + actualMessage.ToString().Split('.').Last(), LogMessageType.Community);

            if(methods.ContainsKey(actualMessage.MessageID))
            {
                executionTask = Task.Run(() =>
                {
                    methods[actualMessage.MessageID].Invoke(actualMessage, client);
                });
            }
            else
            {
                executionTask = Task.Run(() =>
                {
                    if (client.Debug)
                        client.Logger.Log("NO HANDLER : " + actualMessage.ToString().Split('.').Last(), LogMessageType.Admin);
                });
            }
        }
        #endregion

        #region Public Methods
        public void RegisterFrame(Type type)
        {
            object obj = Activator.CreateInstance(type);
            foreach (var methodInfo in type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy))
            {
                MessageHandlerAttribute[] attributes = methodInfo.GetCustomAttributes<MessageHandlerAttribute>().ToArray();
                if (attributes.Length != 0)
                {
                    ParameterInfo[] parameters = methodInfo.GetParameters();
                    if (parameters.Length != 2)
                    {
                        throw new Exception(string.Format("Only two parameters is allowed to use the MessageHandler attribute. (method {0})", methodInfo.Name));
                    }

                    methods.Add(attributes.First().MessageId, new MethodHandler(methodInfo, obj, attributes));
                }
            }
        }

        public void UnRegisterFrame(Type type)
        {
            object obj = Activator.CreateInstance(type);
            foreach (var methodInfo in type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy))
            {
                MessageHandlerAttribute[] attributes = methodInfo.GetCustomAttributes<MessageHandlerAttribute>().ToArray();
                if (attributes.Length != 0)
                {
                    ParameterInfo[] parameters = methodInfo.GetParameters();
                    if (parameters.Length != 2)
                    {
                        throw new Exception(string.Format("Only two parameters is allowed to use the MessageHandler attribute. (method {0})", methodInfo.Name));
                    }

                    methods.Remove(attributes.First().MessageId);
                }
            }
        }

        public void Dispatch(NetworkMessage msg)
        {
            msgQueue.Enqueue(msg);
        }
        #endregion
    }
}
