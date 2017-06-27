using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using Cookie.API.Network;
using Cookie.API.Protocol;
using Cookie.API.Utils.Extensions;
using Cookie.API.Utils.IO;

namespace Cookie.API.Messages
{
    public class MessageReceiver : IMessageBuilder
    {
        private readonly Dictionary<uint, Func<NetworkMessage>> _constructors = new Dictionary<uint, Func<NetworkMessage>>(800);
        private readonly Dictionary<uint, Type> _messages = new Dictionary<uint, Type>(800);

        #region IMessageBuilder Members

        /// <summary>
        ///   Gets instance of the message defined by id thanks to BigEndianReader.
        /// </summary>
        /// <param name = "id">id.</param>
        /// <returns></returns>
        public NetworkMessage BuildMessage(uint id, IDataReader reader)
        {
            if (!_messages.ContainsKey(id))
                throw new MessageNotFoundException($"NetworkMessage <id:{id}> doesn't exist");

            var message = _constructors[id]();

            if (message == null)
                throw new MessageNotFoundException($"Constructors[{id}] (delegate {_messages[id]}) does not exist");

            message.Unpack(reader);

            return message;
        }

        #endregion

        /// <summary>
        ///   Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            var asm = Assembly.GetAssembly(typeof(MessageReceiver));

            foreach (var type in asm.GetTypes())
            {
                if (!type.IsSubclassOf(typeof(NetworkMessage)))
                    continue;

                var fieldId = type.GetField("ProtocolId");

                if (fieldId == null) continue;
                var id = (uint)fieldId.GetValue(type);
                if (_messages.ContainsKey(id))
                    throw new AmbiguousMatchException(
                        $"MessageReceiver() => {id} item is already in the dictionary, old type is : {_messages[id]}, new type is  {type}");

                _messages.Add(id, type);

                var ctor = type.GetConstructor(Type.EmptyTypes);

                if (ctor == null)
                    throw new Exception(
                        $"'{type}' doesn't implemented a parameterless constructor");

                _constructors.Add(id, ctor.CreateDelegate<Func<NetworkMessage>>());
            }
        }

        public Type GetMessageType(uint id)
        {
            if (!_messages.ContainsKey(id))
                throw new MessageNotFoundException($"NetworkMessage <id:{id}> doesn't exist");

            return _messages[id];
        }

        #region Nested type: MessageNotFoundException

        [Serializable]
        public class MessageNotFoundException : Exception
        {
            public MessageNotFoundException()
            {
            }

            public MessageNotFoundException(string message)
                : base(message)
            {
            }

            public MessageNotFoundException(string message, Exception inner)
                : base(message, inner)
            {
            }

            protected MessageNotFoundException(
                SerializationInfo info,
                StreamingContext context)
                : base(info, context)
            {
            }
        }

        #endregion
    }
}