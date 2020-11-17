using Cookie.API.Datacenter;
using Cookie.API.Game.Map;
using Cookie.API.Gamedata.D2o;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Utils.IO;
using Cookie.Core;
using Cookie.Core.Pathmanager;
using MoonSharp.Interpreter;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolBuilder
{
    [MoonSharpUserData]
    public class StaticInventory
    {
        public bool UseItem(int arg)
        {
            Console.WriteLine(arg);
            return true;
        }
    }
    class Program
    {
        static readonly Dictionary<string, string> dataType = new Dictionary<string, string>
        {
            {"Boolean", "bool"},
            {"Byte", "sbyte"},
            {"ByteArray", "byte[]"},
            {"Double", "double"},
            {"Float", "float"},
            {"Int", "int"},
            {"Short", "short"},
            {"UTF", "string"},
            {"UnsignedByte", "byte"},
            {"UnsignedInt", "uint"},
            {"UnsignedShort", "ushort"},
            {"VarInt", "int"},
            {"VarLong", "long"},
            {"VarShort", "short"},
            {"VarUhInt", "uint"},
            {"VarUhLong", "ulong"},
            {"VarUhShort", "ushort"},
            {"SByte", "sbyte" }
        };
        static readonly Dictionary<string, string> readType = new Dictionary<string, string>
        {
            {"Byte", "SByte"},
            {"UnsignedByte", "Byte"},
            {"ByteArray", "Bytes"}
        };

        static void LogMethod(string str)
        {
            Console.WriteLine(str);
        }
        static int ItemCount(int ItemId)
        {
            return ItemId;
        }
        static void Main(string[] args)
        {
            
        }

        #region Network Parser
        static void NetworkParser()
        {
            System.IO.Directory.CreateDirectory("./Output/Types/");
            System.IO.Directory.CreateDirectory("./Output/Messages/");
            using (StreamReader stream = new StreamReader("./Input/types_from_id.json"))
            {
                JObject jObject = JObject.Parse(stream.ReadToEnd());
                foreach (var aux in jObject)
                {
                    var type = aux.Value.ToObject<dynamic>();
                    string Name = type.name;
                    using (StreamWriter file = new StreamWriter(string.Format("./Output/Types/{0}.cs", Name)))
                    {
                        #region Includes
                        file.WriteLine("using Cookie.API.Utils.IO;");
                        file.WriteLine("using Cookie.API.Protocol.Enums;");
                        file.WriteLine("using System.Collections.Generic;");
                        file.WriteLine("using Cookie.API.Protocol.Network.Messages;");
                        file.WriteLine("using Cookie.API.Protocol.Network.Types;");
                        file.WriteLine();
                        #endregion
                        #region Namespace
                        file.WriteLine("namespace Cookie.API.Protocol.Network.Types");
                        file.WriteLine("{");
                        string Parent = type.parent;
                        file.WriteLine();
                        file.WriteLine("    public class {0} : {1}", Name, Parent ?? "NetworkType");
                        file.WriteLine("    {");
                        file.WriteLine("        public {0}const ushort ProtocolId = {1};", Parent == null ? "" : "new ", type.protocolId);
                        file.WriteLine();
                        file.WriteLine("        public override ushort TypeID => ProtocolId;");
                        file.WriteLine();
                        List<string> Variables = new List<string>();
                        StringBuilder Deserialize = new StringBuilder();
                        StringBuilder Serialize = new StringBuilder();
                        StringBuilder Constructor = new StringBuilder();
                        //Serialize/Deserialize Method
                        if (Parent != null)
                        {
                            Deserialize.AppendLine("            base.Deserialize(reader);");
                            Serialize.AppendLine("            base.Serialize(writer);");
                        }
                        if (type.boolVars.Count > 0)
                        {
                            Serialize.AppendLine("			var flag = new byte();");
                            Deserialize.AppendLine("			var flag = reader.ReadByte();");
                            int index = 0;
                            foreach (var variable in type.boolVars)
                            {
                                var varName = ((string)variable.name).FirstToUpper();

                                Variables.Add(string.Format("{0} {1}", dataType[(string)variable.type], varName));
                                file.WriteLine("        public {0} {{ get; set; }}", Variables.LastOrDefault());
                                Serialize.AppendLine(string.Format("			flag = BooleanByteWrapper.SetFlag({0}, flag, {1});", index, varName));
                                Deserialize.AppendLine(string.Format("			{0} = BooleanByteWrapper.GetFlag(flag, {1});", varName, index));
                                Constructor.AppendLine(string.Format("            this.{0} = {0};", varName));
                                index++;
                                if (index % 8 == 0 && index != 0)
                                {
                                    Deserialize.AppendLine("			flag = reader.ReadByte();");
                                    Serialize.AppendLine("			writer.WriteByte(flag);");
                                    Serialize.AppendLine("			flag = new byte();");
                                    index = 0;
                                }
                            }
                            Serialize.AppendLine("			writer.WriteByte(flag);");
                        }
                        foreach (var variable in type.vars)
                        {
                            string varRealType = ((string)variable.realType).FirstToUpper();
                            string varType = dataType.ContainsKey((string)variable.type) ? dataType[(string)variable.type] : variable.type;
                            string varReadType = (string)variable.type;
                            string varName = ((string)variable.name).FirstToUpper();

                            if (variable.length == null)//Non List
                            {
                                if (varType == "False")
                                    Variables.Add(string.Format("{0} {1}", varRealType, varName));
                                else
                                    Variables.Add(string.Format("{0} {1}", varType, varName));
                                file.WriteLine("        public {0} {{ get; set; }}", Variables.LastOrDefault());
                                Deserialize.Append(CreateVarDeserialize(varName, varReadType, "", varRealType));
                                Serialize.Append(CreateVarSerialize(varName, varReadType, "", varRealType));
                            }
                            else//List
                            {
                                if ((string)variable.type == "False")
                                    Variables.Add(string.Format("List<{0}> {1}", varRealType, varName));
                                else
                                    Variables.Add(string.Format("List<{0}> {1}", varType, varName));
                                file.WriteLine("        public {0} {{ get; set; }}", Variables.LastOrDefault());
                                Deserialize.Append(CreateVarDeserialize(varName, varReadType, (string)variable.length, varRealType));
                                Serialize.Append(CreateVarSerialize(varName, varReadType, (string)variable.length, varRealType));
                            }
                            Constructor.AppendLine(string.Format("            this.{0} = {0};", varName));
                        }
                        file.WriteLine("        public {0}() {{ }}", Name);
                        file.WriteLine();
                        #region Constructor
                        if (Variables.Count > 0)
                        {
                            file.WriteLine("        public {0}( {1} ){{", Name, String.Join(", ", Variables.ToArray()));
                            file.Write(Constructor.ToString());
                            file.WriteLine("        }");
                            file.WriteLine();
                        }
                        #endregion
                        file.WriteLine("        public override void Serialize(IDataWriter writer)");
                        file.WriteLine("        {");
                        file.Write(Serialize.ToString());
                        file.WriteLine("        }");
                        file.WriteLine();
                        file.WriteLine("        public override void Deserialize(IDataReader reader)");
                        file.WriteLine("        {");
                        file.Write(Deserialize.ToString());
                        file.WriteLine("        }");
                        file.WriteLine("    }");
                        file.WriteLine("}");
                        #endregion
                    }
                }
            }

            using (StreamReader stream = new StreamReader("./Input/msg_from_id.json"))
            {
                JObject jObject = JObject.Parse(stream.ReadToEnd());
                foreach (var aux in jObject)
                {
                    var type = aux.Value.ToObject<dynamic>();
                    string Name = type.name;
                    using (StreamWriter file = new StreamWriter(string.Format("./Output/Messages/{0}.cs", Name)))
                    {
                        #region Includes
                        file.WriteLine("using Cookie.API.Utils.IO;");
                        file.WriteLine("using Cookie.API.Protocol.Enums;");
                        file.WriteLine("using System.Collections.Generic;");
                        file.WriteLine("using Cookie.API.Protocol.Network.Messages;");
                        file.WriteLine("using Cookie.API.Protocol.Network.Types;");
                        file.WriteLine();
                        #endregion
                        #region Namespace
                        file.WriteLine("namespace Cookie.API.Protocol.Network.Messages");
                        file.WriteLine("{");
                        string Parent = type.parent;
                        file.WriteLine();
                        file.WriteLine("    public class {0} : {1}", Name, Parent ?? "NetworkMessage");
                        file.WriteLine("    {");
                        file.WriteLine("        public {0}const ushort ProtocolId = {1};", Parent == null ? "" : "new ", type.protocolId);
                        file.WriteLine();
                        file.WriteLine("        public override ushort MessageID => ProtocolId;");
                        file.WriteLine();
                        List<string> Variables = new List<string>();
                        StringBuilder Deserialize = new StringBuilder();
                        StringBuilder Serialize = new StringBuilder();
                        StringBuilder Constructor = new StringBuilder();
                        //Serialize/Deserialize Method
                        if (Parent != null)
                        {
                            Deserialize.AppendLine("            base.Deserialize(reader);");
                            Serialize.AppendLine("            base.Serialize(writer);");
                        }
                        if (type.boolVars.Count > 0)
                        {
                            Serialize.AppendLine("			var flag = new byte();");
                            Deserialize.AppendLine("			var flag = reader.ReadByte();");
                            int index = 0;
                            foreach (var variable in type.boolVars)
                            {
                                var varName = ((string)variable.name).FirstToUpper();

                                Variables.Add(string.Format("{0} {1}", dataType[(string)variable.type], varName));
                                file.WriteLine("        public {0} {{ get; set; }}", Variables.LastOrDefault());
                                Serialize.AppendLine(string.Format("			flag = BooleanByteWrapper.SetFlag({0}, flag, {1});", index, varName));
                                Deserialize.AppendLine(string.Format("			{0} = BooleanByteWrapper.GetFlag(flag, {1});;", varName, index));
                                Constructor.AppendLine(string.Format("            this.{0} = {0};", varName));
                                index++;
                            }
                            Serialize.AppendLine("			writer.WriteByte(flag);");
                        }
                        foreach (var variable in type.vars)
                        {
                            if (variable.length == null)//Non List
                            {
                                if (dataType.ContainsKey((string)variable.type))
                                    Variables.Add(string.Format("{0} {1}", dataType[(string)variable.type], ((string)variable.name).FirstToUpper()));
                                else if ((string)variable.type == "False")
                                    Variables.Add(string.Format("{0} {1}", ((string)variable.realType).FirstToUpper(), ((string)variable.name).FirstToUpper()));
                                else
                                    Variables.Add(string.Format("{0} {1}", variable.type, ((string)variable.name).FirstToUpper()));
                                file.WriteLine("        public {0} {{ get; set; }}", Variables.LastOrDefault());
                                Deserialize.Append(CreateVarDeserialize(((string)variable.name).FirstToUpper(), (string)variable.type, "", ((string)variable.realType).FirstToUpper()));
                                Serialize.Append(CreateVarSerialize(((string)variable.name).FirstToUpper(), (string)variable.type, "", ((string)variable.realType).FirstToUpper()));
                            }
                            else//List
                            {
                                if (dataType.ContainsKey((string)variable.type))//List of Some common var type
                                    Variables.Add(string.Format("List<{0}> {1}", dataType[(string)variable.type], ((string)variable.name).FirstToUpper()));
                                else if ((string)variable.type == "False")
                                    Variables.Add(string.Format("List<{0}> {1}", ((string)variable.realType).FirstToUpper(), ((string)variable.name).FirstToUpper()));
                                else
                                    Variables.Add(string.Format("List<{0}> {1}", variable.type, ((string)variable.name).FirstToUpper()));
                                file.WriteLine("        public {0} {{ get; set; }}", Variables.LastOrDefault());
                                Deserialize.Append(CreateVarDeserialize(((string)variable.name).FirstToUpper(), (string)variable.type, (string)variable.length, ((string)variable.realType).FirstToUpper()));
                                Serialize.Append(CreateVarSerialize(((string)variable.name).FirstToUpper(), (string)variable.type, (string)variable.length, ((string)variable.realType).FirstToUpper()));
                            }
                            Constructor.AppendLine(string.Format("            this.{0} = {0};", ((string)variable.name).FirstToUpper()));
                        }
                        file.WriteLine("        public {0}() {{ }}", Name);
                        file.WriteLine();
                        #region Constructor
                        if (Variables.Count > 0)
                        {
                            file.WriteLine("        public {0}( {1} ){{", Name, String.Join(", ", Variables.ToArray()));
                            file.Write(Constructor.ToString());
                            file.WriteLine("        }");
                            file.WriteLine();
                        }
                        #endregion
                        file.WriteLine("        public override void Serialize(IDataWriter writer)");
                        file.WriteLine("        {");
                        file.Write(Serialize.ToString());
                        file.WriteLine("        }");
                        file.WriteLine();
                        file.WriteLine("        public override void Deserialize(IDataReader reader)");
                        file.WriteLine("        {");
                        file.Write(Deserialize.ToString());
                        file.WriteLine("        }");
                        file.WriteLine("    }");
                        file.WriteLine("}");
                        #endregion
                    }
                }
            }
        }
        static string CreateVarDeserialize(string varName, string varType, string lengthType = "", string realType = "False")
        {
            //Check if it contains fixed size
            int.TryParse(lengthType, out int FixedSize);
            bool isPrimitive = dataType.ContainsKey(varType);
            bool ioOverwriteType = readType.ContainsKey(varType);

            StringBuilder output = new StringBuilder();
            if (lengthType != "")//IsVector
            {

                if (FixedSize == 0)
                    output.AppendLine(string.Format("            var {0}Count = reader.Read{1}();", varName, lengthType));
                else
                    output.AppendLine(string.Format("            var {0}Count = {1};", varName, lengthType));

                if(isPrimitive)
                    output.AppendLine(string.Format("            {0} = new List<{1}>();", varName, dataType[varType]));
                else if (varType == "False")
                    output.AppendLine(string.Format("            {0} = new List<{1}>();", varName, realType));
                else
                    output.AppendLine(string.Format("            {0} = new List<{1}>();", varName, varType));
                output.AppendLine(string.Format("            for (var i = 0; i < {0}Count; i++)", varName));
                output.AppendLine("            {");
                if (isPrimitive)//List of primitive type
                {
                    output.AppendLine(string.Format("                {0}.Add(reader.Read{1}());", varName, ioOverwriteType ? readType[varType] : varType));
                }
                else if(varType == "False")
                {
                    output.AppendLine(string.Format("                {0} objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());", realType));
                    output.AppendLine(string.Format("                objectToAdd.Deserialize(reader);"));
                    output.AppendLine(string.Format("                {0}.Add(objectToAdd);", varName));
                }
                else
                {
                    output.AppendLine(string.Format("                var objectToAdd = new {0}();", varType));
                    output.AppendLine(string.Format("                objectToAdd.Deserialize(reader);"));
                    output.AppendLine(string.Format("                {0}.Add(objectToAdd);", varName));
                }
                output.AppendLine("            }");
            }
            else
            {
                if(isPrimitive)
                    if (varType == "ByteArray")  
                        output.AppendLine(string.Format("            {0} = reader.ReadBytes(reader.ReadVarInt());", varName));
                    else 
                        output.AppendLine(string.Format("            {0} = reader.Read{1}();", varName, ioOverwriteType ? readType[varType] : varType));
                else if (varType == "False")
                {
                    output.AppendLine(string.Format("            {0} = ProtocolTypeManager.GetInstance(reader.ReadUShort());", varName));
                    output.AppendLine(string.Format("            {0}.Deserialize(reader);", varName));
                }
                else
                { 
                    output.AppendLine(string.Format("            {0} = new {1}();", varName, varType));
                    output.AppendLine(string.Format("            {0}.Deserialize(reader);", varName));
                }
            }
            return output.ToString();
        }
        static string CreateVarSerialize(string varName, string varType, string lengthType = "", string realType = "False")
        {
            //Check if it contains fixed size
            int.TryParse(lengthType, out int FixedSize);
            bool isPrimitive = dataType.ContainsKey(varType);
            bool ioOverwriteType = readType.ContainsKey(varType);

            StringBuilder output = new StringBuilder();
            if (lengthType != "")//IsVector
            {
                //Check if it contains fixed size
                if (FixedSize == 0) //if doesnt 
                     output.AppendLine(string.Format("			writer.Write{0}(({1}){2}.Count);", lengthType, dataType[lengthType], varName));
                else // if it does contain fixed size
                    output.AppendLine(string.Format("			if({0}.Count > {1}) throw new System.Exception(\"{0} Count returned greater than {1}\");", varName, FixedSize));
                output.AppendLine(string.Format("			foreach (var x in {0})", varName));
                output.AppendLine("			{");
                if (dataType.ContainsKey(varType))//List of primitive type
                {
                    output.AppendLine(string.Format("				writer.Write{0}(x);", ioOverwriteType ? readType[varType] : varType));
                }
                else
                {
                    output.AppendLine("				x.Serialize(writer);");
                }
                output.AppendLine("			}");
            }
            else
            {
                if(isPrimitive)
                    if(varType == "ByteArray")
                    {
                        output.AppendLine(string.Format("            writer.WriteVarInt({0}.Length);", varName));
                        output.AppendLine(string.Format("            writer.WriteBytes({0});", varName));
                    }
                    else
                        output.AppendLine(string.Format("            writer.Write{0}({1});", ioOverwriteType ? readType[varType] : varType, varName));
                else
                {
                    //output.AppendLine(string.Format("            writer.WriteUShort({0}.TypeID);", varName));
                    output.AppendLine(string.Format("            {0}.Serialize(writer);", varName));
                }
            }
            return output.ToString();
        }
        #endregion
    }
    public static class MyExtensions
    {
        public static string FirstToUpper(this string input)
        {
            return (char.ToUpper(input[0]) + input.Substring(1));
        }
    }
}
