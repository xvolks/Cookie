using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using Cookie.API.Utils.Extensions;

namespace Cookie.API.Protocol
{
    public static class ProtocolTypeManager
    {
        private static readonly Dictionary<ushort, Type> Types = new Dictionary<ushort, Type>(400);
        private static readonly Dictionary<ushort, Type> Messages = new Dictionary<ushort, Type>(1000);

        private static readonly Dictionary<ushort, Func<object>> TypesConstructors = new Dictionary<ushort, Func<object>>(400);
        private static readonly Dictionary<ushort, Func<object>> MessagesConstructors = new Dictionary<ushort, Func<object>>(1000);

        public static void Initialize()
        {
            var asm = Assembly.GetAssembly(typeof(ProtocolTypeManager));
            foreach (var type in asm.GetTypes())
            {
                //Console.WriteLine(type);
                if (type.Namespace == null || !type.Namespace.Contains("Cookie.API.Protocol.Network.Types"))
                    continue;

                var field = type.GetField("ProtocolId");

                if (field == null) continue;
                var id = (ushort) field.GetValue(type);

                Types.Add(id, type);

                var ctor = type.GetConstructor(Type.EmptyTypes);

                if (ctor == null)
                    throw new Exception($"'{type}' doesn't implemented a parameterless constructor");

                //TypesConstructors.Add(id, ctor.CreateDelegate<Func<object>>());
            }

            Console.WriteLine($@"<{Types.Count}> type(s) loaded.");
        }
        public static void InitAlternative()
        {
            var asm = Assembly.GetAssembly(typeof(ProtocolTypeManager));
            foreach (var message in asm.GetTypes())
            {
                Console.WriteLine(message);
                if (message.Namespace == null || !message.Namespace.Contains("Cookie.API.Protocol.Network.Messages"))
                    continue;

                var field = message.GetField("ProtocolId");

                if (field == null) continue;
                var id = (ushort)field.GetValue(message);
                if(!Messages.ContainsKey(id))
                    Messages.Add(id, message);

                var ctor = message.GetConstructor(Type.EmptyTypes);

                if (ctor == null)
                    throw new Exception($"'{message}' doesn't implemented a parameterless constructor");
                if(!MessagesConstructors.ContainsKey(id))
                    MessagesConstructors.Add(id, ctor.CreateDelegate<Func<object>>());
            }
            Console.WriteLine($@"<{Messages.Count}> messages(s) loaded.");
        }

        public static T GetInstance<T>(ushort id) where T : class
        {
            if (!Types.ContainsKey(id))
                if (Messages.ContainsKey(id))
                    return MessagesConstructors[id]() as T;
            return TypesConstructors[id]() as T;
        }
        public static dynamic GetInstance(ushort id)
        {
            if (!Types.ContainsKey(id))
                throw new Exception("No id<"+ id + "> found");
             return Activator.CreateInstance(Types[id]);
        }

        [Serializable]
        public class ProtocolTypeNotFoundException : Exception
        {
            public ProtocolTypeNotFoundException()
            {
            }

            public ProtocolTypeNotFoundException(string message)
                : base(message)
            {
            }

            public ProtocolTypeNotFoundException(string message, Exception inner)
                : base(message, inner)
            {
            }

            protected ProtocolTypeNotFoundException(
                SerializationInfo info,
                StreamingContext context)
                : base(info, context)
            {
            }
        }
    }
}