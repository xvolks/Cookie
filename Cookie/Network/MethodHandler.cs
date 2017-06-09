using Cookie.Core;
using System.Reflection;

namespace Cookie
{
    public class MethodHandler
    {
        public MethodInfo Method { get; private set; }
        public object Instance { get; private set; }
        public MessageHandlerAttribute[] Attributes { get; private set; }

        public MethodHandler(MethodInfo method, object instance, MessageHandlerAttribute[] attributes)
        {
            Method = method;
            Instance = instance;
            Attributes = attributes;
        }

        public void Invoke(NetworkMessage message, DofusClient client)
        {
            Method.Invoke(Instance, new object[] { client, message });
        }
    }
}
