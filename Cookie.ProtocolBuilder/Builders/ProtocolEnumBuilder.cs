using System.Collections.Generic;
using System.Linq;
using Cookie.ProtocolBuilder.Generator;
using Cookie.ProtocolBuilder.Parsers;
using static System.Console;

namespace Cookie.ProtocolBuilder.Builders
{
    namespace Cookie.ProtocolBuilder.Builders
    {
        public class ProtocolEnumBuilder
        {
            public ProtocolEnumBuilder(IEnumerable<EnumParser> enumWriters)
            {
                EnumWriters = enumWriters.ToList();
            }

            public List<EnumParser> EnumWriters { get; }

            public void ParseFiles()
            {
                EnumWriters.ForEach(pc => pc.ParseFile());
            }

            public void GenerateFiles()
            {
                EnumWriters.ForEach(pc =>
                {
                    new EnumGenerator().WriteFile(pc.Class);
                    WriteLine($"> Parsing {pc.Class.Name} ...");
                });
            }
        }
    }
}