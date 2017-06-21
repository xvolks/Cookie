using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using Cookie.Extensions;

namespace Cookie.Network
{
    public static class ProtocolTypeManager
    {
        private static readonly Dictionary<short, Type> Types = new Dictionary<short, Type>(200);

        private static readonly Dictionary<short, Func<object>> TypesConstructors =
            new Dictionary<short, Func<object>>(200);

        public static void Initialize()
        {
            var asm = Assembly.GetAssembly(typeof(ProtocolTypeManager));

            foreach (var type in asm.GetTypes())
            {
                if (type.Namespace == null || !type.Namespace.Contains("Protocol.Network.Types"))
                    continue;

                var field = type.GetField("ProtocolId");

                if (field == null) continue;
                var id = (short) field.GetValue(type);

                Types.Add(id, type);

                var ctor = type.GetConstructor(Type.EmptyTypes);

                if (ctor == null)
                    throw new Exception($"'{type}' doesn't implemented a parameterless constructor");

                TypesConstructors.Add(id, ctor.CreateDelegate<Func<object>>());
            }

            Console.WriteLine($@"<{Types.Count}> type(s) loaded.");
        }

        public static T GetInstance<T>(short id) where T : class
        {
            if (!Types.ContainsKey(id))
                Console.WriteLine($@"Type <id:{id}> doesn't exist");

            return TypesConstructors[id]() as T;
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