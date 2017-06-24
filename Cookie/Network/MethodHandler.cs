using System.Reflection;
using Cookie.API.Network;
using Cookie.API.Protocol;
using Cookie.Core;

namespace Cookie
{
    public class MethodHandler
    {
        public MethodHandler(MethodInfo method, object instance, MessageHandlerAttribute[] attributes)
        {
            Method = method;
            Instance = instance;
            Attributes = attributes;
        }

        public MethodInfo Method { get; }
        public object Instance { get; }
        public MessageHandlerAttribute[] Attributes { get; }

        public void Invoke(NetworkMessage message, DofusClient client)
        {
            Method.Invoke(Instance, new object[] {client, message});
        }
    }
}