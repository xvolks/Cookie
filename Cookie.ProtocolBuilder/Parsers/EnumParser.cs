using System;
using System.Collections.Generic;
using Cookie.ProtocolBuilder.Dictionnary;
using Cookie.ProtocolBuilder.Protocol;

namespace Cookie.ProtocolBuilder.Parsers
{
    public class EnumParser
    {
        public EnumParser(string str)
        {
            FileToTranslate = str;
            Class = new ProtocolEnum();
        }

        public ProtocolEnum Class { get; }
        public string FileToTranslate { get; }

        public void ParseFile()
        {
            ParseClassInformations();
        }

        private void ParseClassInformations()
        {
            var m = RegularExpression.GetRegex(RegexEnum.Enum).Match(FileToTranslate);
            if (!m.Success)
                throw new Exception("The class is not a valide as3 class");
            Class.Name = m.Groups["name"].Value;
            m = RegularExpression.GetRegex(RegexEnum.EnumItem).Match(FileToTranslate);
            var newItems = new List<ProtocolEnumVariable>();
            while (m.Success)
            {
                var newItem = new ProtocolEnumVariable
                {
                    Name = m.Groups["name"].Value,
                    Value = m.Groups["value"].Value
                };
                newItems.Add(newItem);
                m = m.NextMatch();
            }
            Class.Items = newItems.ToArray();
        }
    }
}