using System.Collections.Generic;
using System.Linq;
using Cookie.ProtocolBuilder.Dictionnary;
using Cookie.ProtocolBuilder.Protocol;
using Cookie.ProtocolBuilder.Protocol.Enums;

namespace Cookie.ProtocolBuilder.Parsers
{
    public class ParserUtility
    {
        public static string GetIParent(string parent, string @interface)
        {
            if (@interface == "INetworkType" && parent != "implements")
                return parent;
            if (@interface == "INetworkType" && parent == "implements")
                return "NetworkType";
            return parent;
        }

        public static string GetNamespace(string @namespace, int removeCount = 0)
        {
            if (!@namespace.Contains("com.ankamagames.dofus.network"))
                return @namespace;
            @namespace = @namespace.Replace("com.ankamagames.dofus.network.", "");
            var nameSpaceSplited = @namespace.Split('.');
            @namespace = "";
            for (var i = 0; i < nameSpaceSplited.Length - removeCount; i++)
            {
                var str = nameSpaceSplited[i];
                @namespace += str.Substring(0, 1).ToUpper() + str.Remove(0, 1) + ".";
            }
            return string.IsNullOrEmpty(@namespace) ? @namespace : @namespace.Remove(@namespace.Length - 1, 1);
        }

        public static string[] GetImports(string[] imports)
        {
            var retVal = new List<string>();
            foreach (var import in imports)
            {
                if (import.ToLower().Contains("com.ankamagames.jerakine"))
                    continue;
                switch (import.ToLower())
                {
                    case "com.ankamagames.jerakine.network":
                        break;
                    case "com.ankamagames.jerakine.network.networkmessage":
                        break;
                    case "com.ankamagames.jerakine.network.inetworkmessage":
                        break;
                    case "com.ankamagames.jerakine.network.inetworktype":
                        break;
                    case "com.ankamagames.jerakine.network.networkType":
                        break;
                    case "__AS3__.vec.vector":
                        break;
                    case "flash.utils.idataoutput":
                        break;
                    case "flash.utils.bytearray":
                        break;
                    case "flash.utils.idatainput":
                        break;
                    case "com.ankamagames.dofus.network.protocoltypeManager":
                        break;
                    case "com.ankamagames.jerakine.network.utils.booleanbyteWrapper":
                        break;
                    default:
                        retVal.Add(GetNamespace(import, 1));
                        break;
                }
            }

            retVal.Add("Utils.IO");
            return retVal.ToArray();
        }

        public static string GetName(string name)
        {
            switch (name)
            {
                case "id":
                    return "objectId";
                default:
                    return name;
            }
        }

        public static ProtocolClassVariable[] SortVars(ProtocolClassVariable[] vars, string fileStr)
        {
            var varsDictionary = vars.ToDictionary(v => v.Name);
            var retVal = new List<ProtocolClassVariable>();
            var lines = (fileStr + (char) 10 + (char) 10 + (char) 10 + (char) 10).Split((char) 10);
            var boolCount = 0;

            for (var index = 0; index < lines.Length - 4; index++)
            {
                var linesM1 = "";
                if (index > 1)
                    linesM1 = lines[index - 1];
                var line = lines[index];
                var line2 = lines[index + 1];
                var line3 = lines[index + 2];
                var line4 = lines[index + 4];

                var m = RegularExpression.GetRegex(RegexEnum.ReadFlagMetode).Match(line);
                if (m.Success)
                {
                    var currentVar = varsDictionary[m.Groups["name"].Value];
                    currentVar.ObjectType = "bool";
                    currentVar.MethodType = ReadMethodType.BooleanByteWraper;
                    currentVar.ReadMethod = m.Groups["flag"].Value;
                    currentVar.WriteMethod = m.Groups["flag"].Value;
                    currentVar.Index = m.Groups["name"].Index;
                    retVal.Insert(boolCount, currentVar);
                    boolCount += 1;
                    continue;
                }
                m = RegularExpression.GetRegex(RegexEnum.ReadMethodPrimitive).Match(line);
                if (m.Success)
                    retVal.Add(varsDictionary[m.Groups["name"].Value]);
                m = RegularExpression.GetRegex(RegexEnum.ReadMethodObject).Match(line);
                if (m.Success)
                {
                    var m2 = RegularExpression.GetRegex(RegexEnum.ReadMethodObjectProtocolManager).Match(linesM1);
                    if (m2.Success)
                    {
                        var var = varsDictionary[m.Groups["name"].Value];
                        var.MethodType = ReadMethodType.ProtocolTypeManager;
                        retVal.Add(var);
                    }
                    else
                    {
                        retVal.Add(varsDictionary[m.Groups["name"].Value]);
                    }
                }
                m = RegularExpression.GetRegex(RegexEnum.ReadVectorMethodObject)
                    .Match(line + (char) 10 + line2 + (char) 10 + line3);
                if (m.Success)
                    retVal.Add(varsDictionary[m.Groups["name"].Value]);
                m = RegularExpression.GetRegex(RegexEnum.ReadVectorMethodProtocolManager)
                    .Match(line + (char) 10 + line2 + (char) 10 + line3 + (char) 10 + line4);
                if (m.Success)
                {
                    var var = varsDictionary[m.Groups["name"].Value];
                    var.ObjectType = m.Groups["type"].Value;
                    var.MethodType = ReadMethodType.ProtocolTypeManager;
                    retVal.Add(var);
                }
                m = RegularExpression.GetRegex(RegexEnum.ReadVectorMethodPrimitive).Match(line + (char) 10 + line2);
                if (m.Success)
                    retVal.Add(varsDictionary[m.Groups["name"].Value]);
            }

            var rv = new List<ProtocolClassVariable>();
            foreach (var newVar in retVal)
            {
                newVar.Name = GetName(newVar.Name);
                rv.Add(newVar);
            }
            return rv.ToArray();
        }
    }
}