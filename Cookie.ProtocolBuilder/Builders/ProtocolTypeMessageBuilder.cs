using System.Collections.Generic;
using System.Linq;
using Cookie.ProtocolBuilder.Generator;
using Cookie.ProtocolBuilder.Parsers;
using static System.Console;

namespace Cookie.ProtocolBuilder.Builders
{
    public class ProtocolTypeMessageBuilder
    {
        public ProtocolTypeMessageBuilder(IEnumerable<TypeMessageParser> classWriters)
        {
            ClassWriters = classWriters.ToList();
        }

        public List<TypeMessageParser> ClassWriters { get; }

        public void ParseFiles()
        {
            ClassWriters.ForEach(pc => pc.ParseFile());
        }

        public void GenerateFiles(bool isType = false)
        {
            ClassWriters.ForEach(pc =>
            {
                new TypeMessageGenerator().WriteFile(pc.Class, isType);
                WriteLine($"> Parsing {pc.Class.Name} ...");
            });
        }
    }
}