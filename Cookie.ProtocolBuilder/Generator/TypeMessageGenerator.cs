using System;
using System.IO;
using System.Linq;
using System.Text;
using Cookie.ProtocolBuilder.Extensions;
using Cookie.ProtocolBuilder.Protocol;
using Cookie.ProtocolBuilder.Protocol.Enums;

namespace Cookie.ProtocolBuilder.Generator
{
    public class TypeMessageGenerator
    {
        public ProtocolClass ClassParsed { get; set; }
        public string ClassContent => Writer.ToString();
        public string ClassPath { get; set; }

        private bool IsType { get; set; }
        private StringBuilder Writer { get; set; }

        public void WriteFile(ProtocolClass protocolClass, bool isType = false)
        {
            ClassParsed = protocolClass;
            Writer = new StringBuilder();
            IsType = isType;
            ClassPath =
                $@"{Directory.GetCurrentDirectory()}\Output\{
                        ClassParsed.Namespace.NamespaceToPath()
                    }\{ClassParsed.Name}.cs";
            CreateRepositories();
            CreateFile();
            GenerateClass();
        }

        public void CreateRepositories()
        {
            var path = $"Output\\{ClassParsed.Namespace.NamespaceToPath()}";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        public void CreateFile()
        {
            if (!File.Exists(ClassPath))
                File.CreateText(ClassPath).Close();
        }

        private void GenerateClass()
        {
            WriteNamespace();
            WriteUsingDirectives();
            WriteClass();
            if (ClassParsed.Name == "RawDataMessage")
            {
                ParseRDM();
            }
            else
            {
                WriteProperties();

                if (ClassParsed.Variables.Length >= 1)
                    WriteConstructor();

                Writer.AppendLine();
                Writer.AppendLine($"        public {ClassParsed.Name}() {{ }}");
                WriteSerializeMethod();
                WriteDeserializeMethod();
            }

            WriteEndClass();

            if (string.IsNullOrEmpty(ClassContent) || !File.Exists(ClassPath)) return;
            File.WriteAllText(ClassPath, ClassContent, Encoding.UTF8);
        }

        private void WriteNamespace()
        {
            Writer.AppendLine(
                $"namespace Cookie.API.Protocol.Network.{ClassParsed.Namespace.NamespaceToCSharpFormat()}");
            Writer.AppendLine("{");
        }

        private void WriteUsingDirectives()
        {
            foreach (var import in ClassParsed.Imports.Where(imp => imp != ""))
                Writer.AppendLine($"    using {import};");
            Writer.AppendLine("");
        }

        private void WriteClass()
        {
            Writer.AppendLine(string.IsNullOrEmpty(ClassParsed.Parent)
                ? $"    public class {ClassParsed.Name}"
                : $"    public class {ClassParsed.Name} : {ClassParsed.Parent}");
            Writer.AppendLine("    {");
        }

        private void WriteProperties()
        {
            if (IsType)
            {
                if (ClassParsed.Parent == "NetworkType")
                {
                    Writer.AppendLine($"        public const ushort ProtocolId = {ClassParsed.MessageId};");
                    Writer.AppendLine("        public override ushort TypeID => ProtocolId;");
                }
                else
                {
                    Writer.AppendLine($"        public new const ushort ProtocolId = {ClassParsed.MessageId};");
                    Writer.AppendLine("        public override ushort TypeID => ProtocolId;");
                }
            }
            else
            {
                if (ClassParsed.Parent == "NetworkMessage")
                {
                    Writer.AppendLine($"        public const ushort ProtocolId = {ClassParsed.MessageId};");
                    Writer.AppendLine("        public override ushort MessageID => ProtocolId;");
                }
                else
                {
                    Writer.AppendLine($"        public new const ushort ProtocolId = {ClassParsed.MessageId};");
                    Writer.AppendLine("        public override ushort MessageID => ProtocolId;");
                }
            }

            foreach (var field in ClassParsed.Variables)
                switch (field.TypeOfVar)
                {
                    case VarType.Primitive:
                        Writer.AppendLine(
                            $"        public {field.ObjectType} {field.Name.Capitalize()} {{ get; set; }}");
                        break;
                    case VarType.Object:
                        Writer.AppendLine(
                            $"        public {field.ObjectType} {field.Name.Capitalize()} {{ get; set; }}");
                        break;
                    case VarType.Vector:
                        Writer.AppendLine(
                            $"        public List<{field.ObjectType}> {field.Name.Capitalize()} {{ get; set; }}");
                        break;
                }
        }

        private void WriteConstructor()
        {
            Writer.AppendLine();

            var fieldsToInit = new StringBuilder();
            var initFields = new StringBuilder();
            foreach (var field in ClassParsed.Variables)
                switch (field.TypeOfVar)
                {
                    case VarType.Primitive:
                        fieldsToInit.Append($"{field.ObjectType} {field.Name.Decapitalize().ToValidName()}, ");
                        initFields.AppendLine(
                            $"            {field.Name.Capitalize()} = {field.Name.Decapitalize().ToValidName()};");
                        break;
                    case VarType.Object:
                        fieldsToInit.Append($"{field.ObjectType} {field.Name.Decapitalize().ToValidName()}, ");
                        initFields.AppendLine(
                            $"            {field.Name.Capitalize()} = {field.Name.Decapitalize().ToValidName()};");
                        break;
                    case VarType.Vector:
                        fieldsToInit.Append($"List<{field.ObjectType}> {field.Name.Decapitalize().ToValidName()}, ");
                        initFields.AppendLine(
                            $"            {field.Name.Capitalize()} = {field.Name.Decapitalize().ToValidName()};");
                        break;
                }
            if (fieldsToInit.Length > 0)
                fieldsToInit.Length -= 2;
            Writer.AppendLine($"        public {ClassParsed.Name}({fieldsToInit})");
            Writer.AppendLine("        {");
            Writer.Append(initFields);
            Writer.AppendLine("        }");
        }

        private void WriteSerializeMethod()
        {
            Writer.AppendLine();
            var initFields = new StringBuilder();
            Writer.AppendLine("        public override void Serialize(IDataWriter writer)");
            Writer.AppendLine("        {");

            if (ClassParsed.Parent != "NetworkMessage" && ClassParsed.Parent != "NetworkType")
                initFields.AppendLine("            base.Serialize(writer);");

            var flag = false;
            foreach (var field in ClassParsed.Variables)
                if (field.MethodType == ReadMethodType.BooleanByteWraper && !flag)
                {
                    flag = true;
                    initFields.AppendLine("            var flag = new byte();");
                }

            var flagCount = ClassParsed.Variables.Count(var => var.MethodType == ReadMethodType.BooleanByteWraper);
            var newflagCount = flagCount;
            foreach (var field in ClassParsed.Variables)
                switch (field.TypeOfVar)
                {
                    case VarType.Primitive:
                        switch (field.MethodType)
                        {
                            case ReadMethodType.Primitive:
                                initFields.AppendLine(
                                    $"            writer.{field.WriteMethod}({field.Name.Capitalize()});");
                                break;
                            case ReadMethodType.BooleanByteWraper:
                                initFields.AppendLine(
                                    $"            flag = BooleanByteWrapper.SetFlag({Convert.ToUInt32(field.ReadMethod)}, flag, {field.Name.Capitalize()});");
                                break;
                        }
                        if (field.MethodType == ReadMethodType.BooleanByteWraper)
                        {
                            newflagCount -= 1;
                            if (flagCount == newflagCount + 8)
                            {
                                flagCount = flagCount - 8;
                                initFields.AppendLine("            writer.WriteByte(flag);");
                            }
                            else if (newflagCount <= 0)
                            {
                                initFields.AppendLine("            writer.WriteByte(flag);");
                            }
                        }
                        continue;
                    case VarType.Object:
                        switch (field.MethodType)
                        {
                            case ReadMethodType.ProtocolTypeManager:
                                initFields.AppendLine(
                                    $"            writer.WriteUShort({field.Name.Capitalize()}.TypeID);");
                                break;
                            case ReadMethodType.SerializeOrDeserialize:
                                break;
                        }
                        initFields.AppendLine($"            {field.Name.Capitalize()}.Serialize(writer);");
                        break;
                    case VarType.Vector:
                        WriteSerializeVector(field, initFields);
                        break;
                }

            Writer.Append(initFields);
            Writer.AppendLine("        }");
            Writer.AppendLine();
        }

        private void WriteSerializeVector(ProtocolClassVariable field, StringBuilder init)
        {
            init.AppendLine(!string.IsNullOrEmpty(field.VectorFieldWrite)
                ? $"            writer.{field.VectorFieldWrite}({field.VectorFieldWrite.ToConverterCSharp()}{field.Name.Capitalize()}.Count);"
                : $"            writer.WriteShort((short){field.Name.Capitalize()}.Count);");
            init.AppendLine(
                $"            for (var {field.Name}Index = 0; {field.Name}Index < {field.Name.Capitalize()}.Count; {field.Name}Index++)");
            init.AppendLine("            {");
            switch (field.MethodType)
            {
                case ReadMethodType.ProtocolTypeManager:
                    init.AppendLine(
                        $"                var objectToSend = {field.Name.Capitalize()}[{field.Name}Index];");
                    init.AppendLine("                writer.WriteUShort(objectToSend.TypeID);");
                    init.AppendLine("                objectToSend.Serialize(writer);");
                    break;
                case ReadMethodType.SerializeOrDeserialize:
                    init.AppendLine(
                        $"                var objectToSend = {field.Name.Capitalize()}[{field.Name}Index];");
                    init.AppendLine("                objectToSend.Serialize(writer);");
                    break;
                case ReadMethodType.VectorPrimitive:
                    init.AppendLine(
                        $"                writer.{field.WriteMethod}({field.Name.Capitalize()}[{field.Name}Index]);");
                    break;
            }
            init.AppendLine("            }");
        }


        private void WriteDeserializeMethod()
        {
            var initFields = new StringBuilder();
            Writer.AppendLine("        public override void Deserialize(IDataReader reader)");
            Writer.AppendLine("        {");

            if (ClassParsed.Parent != "NetworkMessage" && ClassParsed.Parent != "NetworkType")
                initFields.AppendLine("            base.Deserialize(reader);");

            var flag = false;
            foreach (var field in ClassParsed.Variables)
                if (field.MethodType == ReadMethodType.BooleanByteWraper && !flag)
                {
                    flag = true;
                    initFields.AppendLine("            var flag = reader.ReadByte();");
                }

            var flagCount = ClassParsed.Variables.Count(var => var.MethodType == ReadMethodType.BooleanByteWraper);
            var newflagCount = flagCount;
            foreach (var field in ClassParsed.Variables)
                switch (field.TypeOfVar)
                {
                    case VarType.Primitive:
                        switch (field.MethodType)
                        {
                            case ReadMethodType.Primitive:
                                initFields.AppendLine(
                                    $"            {field.Name.Capitalize()} = reader.{field.ReadMethod}();");
                                break;
                            case ReadMethodType.BooleanByteWraper:
                                initFields.AppendLine(
                                    $"            {field.Name.Capitalize()} = BooleanByteWrapper.GetFlag(flag, {Convert.ToInt32(field.ReadMethod)});");
                                break;
                        }
                        if (field.MethodType == ReadMethodType.BooleanByteWraper)
                        {
                            newflagCount -= 1;
                            if (flagCount == newflagCount + 8)
                            {
                                flagCount = flagCount - 8;
                                initFields.AppendLine("            flag = reader.ReadByte();");
                            }
                        }
                        continue;
                    case VarType.Object:
                        switch (field.MethodType)
                        {
                            case ReadMethodType.ProtocolTypeManager:
                                initFields.AppendLine(
                                    $"            {field.Name.Capitalize()} = ProtocolTypeManager.GetInstance<{field.ObjectType}>(reader.ReadUShort());");
                                break;
                            case ReadMethodType.SerializeOrDeserialize:
                                initFields.AppendLine(
                                    $"            {field.Name.Capitalize()} = new {field.ObjectType}();");
                                break;
                        }
                        initFields.AppendLine($"            {field.Name.Capitalize()}.Deserialize(reader);");
                        continue;
                    case VarType.Vector:
                        WriteDeserializeVector(field, initFields);
                        continue;
                }

            Writer.Append(initFields);
            Writer.AppendLine("        }");
            Writer.AppendLine();
        }

        private static void WriteDeserializeVector(ProtocolClassVariable field, StringBuilder init)
        {
            init.AppendLine(!string.IsNullOrEmpty(field.VectorFieldRead)
                ? $"            var {field.Name}Count = reader.{field.VectorFieldRead}();"
                : $"            var {field.Name}Count = reader.ReadUShort();");
            init.AppendLine($"            {field.Name.Capitalize()} = new List<{field.ObjectType}>();");
            init.AppendLine(
                $"            for (var {field.Name}Index = 0; {field.Name}Index < {field.Name}Count; {field.Name}Index++)");
            init.AppendLine("            {");
            switch (field.MethodType)
            {
                case ReadMethodType.ProtocolTypeManager:
                    init.AppendLine(
                        $"                var objectToAdd = ProtocolTypeManager.GetInstance<{field.ObjectType}>(reader.ReadUShort());");
                    init.AppendLine("                objectToAdd.Deserialize(reader);");
                    init.AppendLine($"                {field.Name.Capitalize()}.Add(objectToAdd);");
                    break;
                case ReadMethodType.SerializeOrDeserialize:
                    init.AppendLine($"                var objectToAdd = new {field.ObjectType.Capitalize()}();");
                    init.AppendLine("                objectToAdd.Deserialize(reader);");
                    init.AppendLine($"                {field.Name.Capitalize()}.Add(objectToAdd);");
                    break;
                case ReadMethodType.VectorPrimitive:
                    init.AppendLine($"                {field.Name.Capitalize()}.Add(reader.{field.ReadMethod}());");
                    break;
            }
            init.AppendLine("            }");
        }

        private void ParseRDM()
        {
            Writer.AppendLine($"        public const ushort ProtocolId = {ClassParsed.MessageId};");
            Writer.AppendLine("        public override ushort MessageID => ProtocolId;");
            Writer.AppendLine("        public byte[] Content { get; set; }");
            Writer.AppendLine();
            Writer.AppendLine($"        public {ClassParsed.Name}() {{ }}");
            Writer.AppendLine();
            Writer.AppendLine($"        public {ClassParsed.Name}(byte[] content)");
            Writer.AppendLine("        {");
            Writer.AppendLine("            Content = content;");
            Writer.AppendLine("        }");
            Writer.AppendLine();
            Writer.AppendLine("        public override void Serialize(IDataWriter writer)");
            Writer.AppendLine("        {");
            Writer.AppendLine("            var contentLength = Content.Length;");
            Writer.AppendLine("            writer.WriteVarInt(contentLength);");
            Writer.AppendLine("            for (var i = 0; i < contentLength; i++)");
            Writer.AppendLine("             writer.WriteByte(Content[i]);");
            Writer.AppendLine("        }");
            Writer.AppendLine("        public override void Deserialize(IDataReader reader)");
            Writer.AppendLine("        {");
            Writer.AppendLine("            var contentLength = reader.ReadVarInt();");
            Writer.AppendLine("            reader.ReadBytes(contentLength);");
            Writer.AppendLine("        }");
        }

        private void WriteEndClass()
        {
            Writer.AppendLine("    }");
            Writer.AppendLine("}");
        }
    }
}