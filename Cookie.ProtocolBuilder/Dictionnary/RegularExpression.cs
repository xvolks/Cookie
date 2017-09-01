using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Cookie.ProtocolBuilder.Dictionnary
{
    public class RegularExpression : Dictionary<RegexEnum, Regex>
    {
        public static readonly RegularExpression Singleton = new RegularExpression();

        public RegularExpression()
        {
            //As
            Add(RegexEnum.Import, new Regex(@"^\s*import\s+(?<name>[\w|\.]+)\s*;\s*$", RegexOptions.Multiline));
            Add(RegexEnum.Class,
                new Regex(
                    @"public\s*[final]*\s+class\s+(?<name>[\w]+)\s*[extends]*\s*(?<parent>[\w]*)\s[implements\s+]*(?<interface>[\w]*)\s*,*\s*(?<interface2>[\w]*)",
                    RegexOptions.Multiline));
            Add(RegexEnum.ConstId,
                new Regex(
                    @"^\s*public\s*static\s*const\s*(?<name>[\w]+)\s*:\s*(?<type>[\w]+)\s*=\s*(?<value>[\d]+)\s*;\s*$",
                    RegexOptions.Multiline));
            Add(RegexEnum.Namespace, new Regex(@"^\s*package\s+(?<name>[\w|\.]+)\s*$", RegexOptions.Multiline));
            Add(RegexEnum.VarObject,
                new Regex(@"^\s*public\s*var\s*(?<name>[\w]+)\s*:\s*(?<type>[\w]+)\s*;\s*$", RegexOptions.Multiline));
            Add(RegexEnum.VarPrimitive,
                new Regex(
                    @"^\s*(?<porte>public|private)\s+var\s+(?<name>[\w]+)\s*:\s*(?<type>String|Boolean|int|Number|uint|byte)\s*=\s*",
                    RegexOptions.Multiline));
            Add(RegexEnum.VarVector,
                new Regex(
                    @"^\s*(?<porte>public|private)\s+var\s+(?<name>[\w]+)\s*:\s*Vector.\s*<\s*(?<type>[\w]+)\s*>\s*;\s*$",
                    RegexOptions.Multiline));
            Add(RegexEnum.VarVectorFieldRead,
                new Regex(
                    @"^\s*var\s*(?<name>[\w]+)\s*:\s*(?<type>[\w]+)\s*=\s*param1.(?<methode>[\w]+)\(\);\s*\n\s*var\s*(?<name>[\w]+)\s*:\s*(?<type>[\w]+)\s*=\s*0;\s*",
                    RegexOptions.Multiline));
            Add(RegexEnum.VarVectorFieldWrite,
                new Regex(@"^\s*param1.(?<methode>[\w]+)\(this.(?<name>[\w]+).length\);\s*", RegexOptions.Multiline));
            Add(RegexEnum.ReadVectorMethodPrimitive,
                new Regex(
                    @"\s*_\w+_\s*=\s*param1.(?<methode>[\w]+)\(\)\s*;\s*\n\s*this.(?<name>[\w]+).push\(_\w+_\)\s*;\s*",
                    RegexOptions.Multiline));
            Add(RegexEnum.ReadMethodPrimitive,
                new Regex(@"^\s*this.(?<name>[\w]+)\s*=\s*param1.(?<methode>[\w]+)\(\);", RegexOptions.Multiline));
            Add(RegexEnum.ReadVectorMethodObject,
                new Regex(
                    @"^\s*_\w+_\s*=\s*new\s+(?<type>[\w]+)\(\)\s*;\s*\n\s*_\w+_.deserialize\(\s*param1\s*\)\s*;\s*\n\s*this.(?<name>[\w]+).push\(_\w+\)\s*;\s*$",
                    RegexOptions.Multiline));
            Add(RegexEnum.ReadMethodObject, new Regex(@"^\s*this.(?<name>[\w]+).deserialize\([\w]+\);\s*$"));
            Add(RegexEnum.ReadVectorMethodProtocolManager,
                new Regex(
                    @"\s*_[\w]+_\s*=\s*param1.readUnsignedShort\(\);\s*\n\s*_\w+_\s*=\s*ProtocolTypeManager.getInstance\((?<type>[\w]+)\s*,\s*_\w+_\s*\)\s*;\s*\n\s*this.(?<name>[\w]+).push\(_\w+_\)\s*;\s*",
                    RegexOptions.Multiline));
            Add(RegexEnum.ReadMethodObjectProtocolManager,
                new Regex(
                    @"^\s*this.(?<name>[\w]+)\s*=\s*ProtocolTypeManager.getInstance\(\s*(?<type>[\w]+)\s*,\s*[_|\w]+\)\s*;\s*$"));
            Add(RegexEnum.ReadFlagMetode,
                new Regex(
                    @"^\s*this.(?<name>[\w]+)\s*=\s*BooleanByteWrapper.getFlag\(_\w+_\s*,\s*(?<flag>[\d]+)\s*\)\s*;\s*$"));
            Add(RegexEnum.ThrowError, new Regex(@"^\s*throw\s+new\s+Error\s*\("));
            //Enum
            Add(RegexEnum.EnumItem,
                new Regex(
                    @"^\s*public\s+static\s+const\s+(?<name>[\w|_]+)\s*:\s*(?<type>[\w]+)\s*=\s*(?<value>[-+|\d||\w]+)\s*;\s*$",
                    RegexOptions.Multiline));
            Add(RegexEnum.Enum, new Regex(@"^\s*public\s+class\s+(?<name>[\w]+)\s*$", RegexOptions.Multiline));
            //Datacenter
            Add(RegexEnum.VarVectorVector,
                new Regex(
                    @"^\s*(?<porte>public|private)\s+var\s+(?<name>[\w]+)\s*:\s*Vector\s*.<Vector.\s*<\s*(?<type>[\w]+)\s*>>\s*;\s*$",
                    RegexOptions.Multiline));
        }

        public static Regex GetRegex(RegexEnum key)
        {
            return Singleton[key];
        }
    }
}