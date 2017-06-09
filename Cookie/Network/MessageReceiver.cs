using Cookie.Extensions;
using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Cookie
{
    public static class MessageReceiver
    {

        #region Variables

        private static readonly Dictionary<uint, Func<NetworkMessage>> m_constructors = new Dictionary<uint, Func<NetworkMessage>>(800);
        private static readonly Dictionary<uint, Type> m_messages = new Dictionary<uint, Type>(800);

        #endregion

        #region Methods
        public static NetworkMessage BuildMessage(uint id, ICustomDataInput reader)
        {
            if (!m_messages.ContainsKey(id))
            {
                Console.WriteLine(string.Format("INetworkMessage <id:{0}> doesn't exist", id));
                return null;
            }

            NetworkMessage message = m_constructors[id]();

            if (message == null)
            {
                Console.WriteLine(string.Format("Constructors[{0}] (delegate {1}) does not exist", id, m_messages[id]));
                return null;
            }

            var methode = message.GetType().GetMethod("Deserialize");
            methode.Invoke(message, new object[1] { reader });

            return message;
        }

        public static void Initialize()
        {
            Assembly asm = typeof(Protocol.Network.Messages.Handshake.ProtocolRequired).GetTypeInfo().Assembly;

            foreach (Type type in asm.GetTypes())
            {
                if (type.Namespace == null || !type.Namespace.Contains("Network.Messages"))
                    continue;

                FieldInfo fieldId = type.GetField("ProtocolId");

                if (fieldId != null)
                {
                    var id = (uint)fieldId.GetValue(type);
                    if (m_messages.ContainsKey(id))
                        throw new AmbiguousMatchException(
                            string.Format(
                                "MessageReceiver() => {0} item is already in the dictionary, old type is : {1}, new type is  {2}",
                                id, m_messages[id], type));

                    m_messages.Add(id, type);

                    ConstructorInfo ctor = type.GetConstructor(Type.EmptyTypes);

                    if (ctor == null)
                        continue;

                    m_constructors.Add(id, ctor.CreateDelegate<Func<NetworkMessage>>());
                }
            }
            Console.WriteLine(string.Format("<{0}> message(s) loaded.", m_messages.Count));
        }

        public static Type GetMessageType(uint id)
        {
            if (!m_messages.ContainsKey(id))
                throw new MessageNotFoundException(string.Format("INetworkMessage <id:{0}> doesn't exist", id));

            return m_messages[id];
        }



        #endregion

        #region Nested type: MessageNotFoundException


        public class MessageNotFoundException : System.Exception
        {
            public MessageNotFoundException()
            {
            }

            public MessageNotFoundException(string message)
                : base(message)
            {
            }

            public MessageNotFoundException(string message, System.Exception inner)
                : base(message, inner)
            {
            }
        }

        #endregion

    }
}
