using System;

namespace Cookie
{
    public class MessageHandlerAttribute : Attribute
    {
        public Type MessageType { get; private set; }
        public uint MessageId { get; private set; }
        public MessageHandlerAttribute(Type type)
        {
            MessageType = type;
        }

        public MessageHandlerAttribute(uint id)
        {
            MessageId = id;
        }
    }
}
