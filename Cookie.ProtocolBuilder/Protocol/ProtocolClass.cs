using System.Linq;
using Cookie.ProtocolBuilder.Extensions;

namespace Cookie.ProtocolBuilder.Protocol
{
    public class ProtocolClass
    {
        public int MessageId { get; set; }
        public string[] Imports { get; set; }
        public string Name { get; set; }
        public string Namespace { get; set; }
        public string Parent { get; set; }

        public ProtocolClassVariable[] Variables { get; set; }
    }

    public static class ProtocolClassExtensions
    {
        public static string NamespaceToPath(this string s)
        {
            return s.Split('.').Select(name => $@"{name.Capitalize()}")
                .Aggregate((name, next) => $@"{name.Capitalize()}\{next.Capitalize()}");
        }

        public static string NamespaceToCSharpFormat(this string s)
        {
            return s.Split('.').Select(name => $@"{name.Capitalize()}")
                .Aggregate((name, next) => $"{name.Capitalize()}.{next.Capitalize()}");
        }
    }
}