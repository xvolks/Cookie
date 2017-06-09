using Cookie.Extensions;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;

namespace Cookie
{
    public static class ProtocolTypeManager
    {

        private static readonly Dictionary<short, Type> types = new Dictionary<short, Type>(200);
        private static readonly Dictionary<short, Func<object>> typesConstructors = new Dictionary<short, Func<object>>(200);
        public static void Initialize()
        {
            Assembly asm = Assembly.GetAssembly(typeof(ProtocolTypeManager));

            foreach (Type type in asm.GetTypes())
            {
                if (type.Namespace == null || !type.Namespace.Contains("Protocol.Network.Types"))
                    continue;

                FieldInfo field = type.GetField("ProtocolId");

                if (field != null)
                {
                    short id = (short)(field.GetValue(type));

                    types.Add(id, type);

                    ConstructorInfo ctor = type.GetConstructor(Type.EmptyTypes);

                    if (ctor == null)
                        throw new Exception(string.Format("'{0}' doesn't implemented a parameterless constructor", type));

                    typesConstructors.Add(id, ctor.CreateDelegate<Func<object>>());
                }
            }

            Console.WriteLine(string.Format("<{0}> type(s) loaded.", types.Count));
        }

        public static T GetInstance<T>(short id) where T : class
        {
            if (!types.ContainsKey(id))
            {
                Console.WriteLine(string.Format("Type <id:{0}> doesn't exist", id));
            }

            return typesConstructors[id]() as T;
        }

        [Serializable]
        public class ProtocolTypeNotFoundException : System.Exception
        {
            public ProtocolTypeNotFoundException()
            {
            }

            public ProtocolTypeNotFoundException(string message)
                : base(message)
            {
            }

            public ProtocolTypeNotFoundException(string message, System.Exception inner)
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
