using System;
using Cookie.API.Core;

namespace Cookie.API.Messages
{
    public class MessageHandler
    {
        // Constructors
        public MessageHandler(Type messageType, Action<IAccount, object> handler, string pluginName, Type tokenType,
            MessagePriority priority)
        {
            MessageType = messageType;
            Handler = handler;
            PluginName = pluginName;
            TokenType = tokenType;
            Priority = priority;
        }

        public Type MessageType { get; set; }
        public Action<IAccount, object> Handler { get; set; }
        public string PluginName { get; set; }
        public Type TokenType { get; set; }
        public MessagePriority Priority { get; set; }
    }
}