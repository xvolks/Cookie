using System;

namespace Cookie.API.Network
{
    public class MessageHandlerAttribute : Attribute
    {
        public MessageHandlerAttribute(Type type)
        {
            MessageType = type;
        }

        public MessageHandlerAttribute(uint id)
        {
            MessageId = id;
        }

        public Type MessageType { get; }
        public uint MessageId { get; }
    }
}