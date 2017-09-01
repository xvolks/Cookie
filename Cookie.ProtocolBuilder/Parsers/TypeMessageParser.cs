using System;
using System.Collections.Generic;
using System.Linq;
using Cookie.ProtocolBuilder.Dictionnary;
using Cookie.ProtocolBuilder.Protocol;
using Cookie.ProtocolBuilder.Protocol.Enums;

namespace Cookie.ProtocolBuilder.Parsers
{
    public class TypeMessageParser
    {
        public TypeMessageParser(string[] fileStr)
        {
            Class = new ProtocolClass();
            CleanSource(fileStr);
            Brackets = FindBracketsIndexesByLines(fileStr, '{', '}');
        }

        public ProtocolClass Class { get; }

        private List<ProtocolClassVariable> Variables { get; set; }
        private Dictionary<int, int> Brackets { get; }
        private string FileToTranslate { get; set; }
        private string[] FileLines { get; set; }

        private static Dictionary<int, int> FindBracketsIndexesByLines(IReadOnlyList<string> lines, char startDelimter,
            char endDelemiter)
        {
            var elementsStack = new Stack<int>();
            var result = new Dictionary<int, int>();

            for (var i = 0; i < lines.Count; i++)
            {
                if (lines[i].Contains(startDelimter))
                    elementsStack.Push(i);
                if (!lines[i].Contains(endDelemiter)) continue;
                var index = elementsStack.Pop();
                result.Add(index, i);
            }

            return result;
        }


        public void ParseFile()
        {
            ParseImports();
            ParseClassInformations();
            ParseClassVars();
            ParseClassReadOrWriteMethods();
            Class.Variables = ParserUtility.SortVars(Class.Variables, FileToTranslate);
            Class.Variables = Class.Variables.OrderBy(i => i.Index).ToArray();
        }

        private void ParseImports()
        {
            var imports = new List<string>();
            var m = RegularExpression.GetRegex(RegexEnum.Import).Match(FileToTranslate);
            while (m.Success)
            {
                imports.Add(m.Groups["name"].Value);
                m = m.NextMatch();
            }
            if (FileToTranslate.Contains("Vector"))
                imports.Add("System.Collections.Generic");
            Class.Imports = ParserUtility.GetImports(imports.ToArray());
        }

        private void ParseClassInformations()
        {
            var m = RegularExpression.GetRegex(RegexEnum.Class).Match(FileToTranslate);
            if (!m.Success)
                throw new Exception("The class is not a valide as3 class");
            Class.Name = m.Groups["name"].Value;
            Class.Parent = ParserUtility.GetIParent(m.Groups["parent"].Value, m.Groups["interface"].Value);
            m = RegularExpression.GetRegex(RegexEnum.ConstId).Match(FileToTranslate);
            if (m.Success)
                Class.MessageId = Convert.ToInt32(m.Groups["value"].Value);
            m = RegularExpression.GetRegex(RegexEnum.Namespace).Match(FileToTranslate);
            if (m.Success)
                Class.Namespace = ParserUtility.GetNamespace(m.Groups["name"].Value);
            else
                throw new Exception("The class is not a valide as3 class");
        }

        private void ParseClassVars()
        {
            Variables = new List<ProtocolClassVariable>();
            var m = RegularExpression.GetRegex(RegexEnum.VarObject).Match(FileToTranslate);
            while (m.Success)
            {
                var newVar = new ProtocolClassVariable
                {
                    Name = m.Groups["name"].Value,
                    TypeOfVar = VarType.Object,
                    MethodType = ReadMethodType.SerializeOrDeserialize,
                    ObjectType = m.Groups["type"].Value,
                    ReadMethod = "Deserialize",
                    WriteMethod = "Serialize",
                    Index = m.Groups["name"].Index
                };
                Variables.Add(newVar);
                m = m.NextMatch();
            }

            m = RegularExpression.GetRegex(RegexEnum.VarPrimitive).Match(FileToTranslate);
            while (m.Success)
            {
                var newVar = new ProtocolClassVariable
                {
                    TypeOfVar = VarType.Primitive,
                    Name = m.Groups["name"].Value,
                    ObjectType = m.Groups["type"].Value,
                    Index = m.Groups["name"].Index
                };
                Variables.Add(newVar);
                m = m.NextMatch();
            }

            m = RegularExpression.GetRegex(RegexEnum.VarVector).Match(FileToTranslate);
            while (m.Success)
            {
                var newVar = new ProtocolClassVariable
                {
                    TypeOfVar = VarType.Vector,
                    Name = m.Groups["name"].Value,
                    ObjectType = m.Groups["type"].Value,
                    Index = m.Groups["name"].Index
                };
                Variables.Add(newVar);
                m = m.NextMatch();
            }
            Class.Variables = Variables.ToArray();
        }

        private void ParseClassReadOrWriteMethods()
        {
            ParseVectorFields();
            ParsePrimitiveVectorMethode();
            ParsePrimitiveMethode();
            ParseObjectVectorMethode();
            ParseObjectMethode();
            ParseVectorProtocolTypeManagerMethode();
            ParseObjectProtocolManager();
        }

        private void ParseVectorFields()
        {
            var bracketOpen = Array.FindIndex(FileLines, entry => entry.Contains("function serializeAs_"));
            if (!FileLines[bracketOpen].EndsWith("{"))
                bracketOpen++;
            var bracketClose = Brackets[bracketOpen];
            var methodlines = new string[bracketClose - 1 - bracketOpen];
            Array.Copy(FileLines, bracketOpen + 1, methodlines, 0, bracketClose - 1 - bracketOpen);
            var vectorFields = methodlines.Where(line => line.Trim() != "")
                .Aggregate("", (current, line) => current + (line + (char) 10));

            var m = RegularExpression.GetRegex(RegexEnum.VarVectorFieldWrite).Match(vectorFields);
            while (m.Success)
            {
                foreach (var newClass in Class.Variables)
                {
                    if (newClass.Name != m.Groups["name"].Value) continue;
                    newClass.VectorFieldWrite = ReadOrWriteMethod.GetWriteMethode(m.Groups["methode"].Value, "write");
                    newClass.VectorFieldRead = ReadVectorField.GetReadMethode(m.Groups["methode"].Value);
                }
                m = m.NextMatch();
            }
        }

        private void ParsePrimitiveVectorMethode()
        {
            var m = RegularExpression.GetRegex(RegexEnum.ReadVectorMethodPrimitive).Match(FileToTranslate);
            while (m.Success)
            {
                foreach (var newClass in Class.Variables)
                {
                    if (newClass.Name != m.Groups["name"].Value) continue;
                    if ((newClass.ObjectType == "int") & (m.Groups["methode"].Value == "readByte"))
                    {
                        newClass.ReadMethod = "ReadSByte";
                        newClass.WriteMethod = "WriteSByte";
                        newClass.ObjectType = "sbyte";
                    }
                    else if ((newClass.ObjectType == "uint") & (m.Groups["methode"].Value == "readByte"))
                    {
                        newClass.ReadMethod = "ReadByte";
                        newClass.WriteMethod = "WriteByte";
                        newClass.ObjectType = "byte";
                    }
                    else
                    {
                        newClass.ReadMethod = ReadOrWriteMethod.GetReadMethode(m.Groups["methode"].Value, "read");
                        newClass.WriteMethod = ReadOrWriteMethod.GetWriteMethode(m.Groups["methode"].Value, "read");
                        newClass.ObjectType = PrimitiveType.GetTypeByReadMethode(newClass.ReadMethod);
                    }
                    newClass.MethodType = ReadMethodType.VectorPrimitive;
                }
                m = m.NextMatch();
            }
        }

        private void ParsePrimitiveMethode()
        {
            var m = RegularExpression.GetRegex(RegexEnum.ReadMethodPrimitive).Match(FileToTranslate);
            while (m.Success)
            {
                foreach (var newClass in Class.Variables)
                {
                    if (newClass.Name != m.Groups["name"].Value) continue;
                    if ((newClass.ObjectType == "uint") & (m.Groups["methode"].Value == "readUnsignedByte"))
                    {
                        newClass.ReadMethod = "ReadByte";
                        newClass.WriteMethod = "WriteByte";
                        newClass.ObjectType = "byte";
                    }
                    else if ((newClass.ObjectType == "uint") & (m.Groups["methode"].Value == "readByte"))
                    {
                        newClass.ReadMethod = "ReadByte";
                        newClass.WriteMethod = "WriteByte";
                        newClass.ObjectType = "byte";
                    }
                    else if ((newClass.ObjectType == "int") & (m.Groups["methode"].Value == "readByte"))
                    {
                        newClass.ReadMethod = "ReadSByte";
                        newClass.WriteMethod = "WriteSByte";
                        newClass.ObjectType = "sbyte";
                    }
                    else
                    {
                        newClass.ReadMethod = ReadOrWriteMethod.GetReadMethode(m.Groups["methode"].Value, "read");
                        newClass.WriteMethod = ReadOrWriteMethod.GetWriteMethode(m.Groups["methode"].Value, "read");
                        newClass.ObjectType = PrimitiveType.GetTypeByReadMethode(newClass.ReadMethod);
                    }
                    newClass.MethodType = ReadMethodType.Primitive;
                }
                m = m.NextMatch();
            }
            Class.Variables = Variables.ToArray();
        }

        private void ParseObjectVectorMethode()
        {
            var m = RegularExpression.GetRegex(RegexEnum.ReadVectorMethodObject).Match(FileToTranslate);
            while (m.Success)
            {
                foreach (var newClass in Class.Variables)
                {
                    if (newClass.Name != m.Groups["name"].Value) continue;
                    newClass.MethodType = ReadMethodType.SerializeOrDeserialize;
                    newClass.ReadMethod = "Deserialize";
                    newClass.WriteMethod = "Serialize";
                    newClass.ObjectType = m.Groups["type"].Value;
                }
                m = m.NextMatch();
            }
        }

        private void ParseObjectMethode()
        {
            var m = RegularExpression.GetRegex(RegexEnum.ReadMethodObject).Match(FileToTranslate);
            while (m.Success)
            {
                foreach (var newClass in Class.Variables)
                {
                    if (newClass.Name != m.Groups["name"].Value) continue;
                    newClass.MethodType = ReadMethodType.SerializeOrDeserialize;
                    newClass.ReadMethod = "Deserialize";
                    newClass.WriteMethod = "Serialize";
                }
                m = m.NextMatch();
            }
        }

        private void ParseVectorProtocolTypeManagerMethode()
        {
            var m = RegularExpression.GetRegex(RegexEnum.ReadVectorMethodProtocolManager).Match(FileToTranslate);
            while (m.Success)
            {
                foreach (var newClass in Class.Variables)
                {
                    if (newClass.Name != m.Groups["name"].Value) continue;
                    newClass.ObjectType = m.Groups["type"].Value;
                    newClass.MethodType = ReadMethodType.ProtocolTypeManager;
                }
                m = m.NextMatch();
            }
        }

        private void ParseObjectProtocolManager()
        {
            var m = RegularExpression.GetRegex(RegexEnum.ReadMethodObjectProtocolManager).Match(FileToTranslate);
            while (m.Success)
            {
                foreach (var newClass in Class.Variables)
                {
                    if (newClass.Name != m.Groups["name"].Value) continue;
                    newClass.MethodType = ReadMethodType.ProtocolTypeManager;
                    newClass.ObjectType = m.Groups["type"].Value;
                }
                m = m.NextMatch();
            }
        }

        private void CleanSource(IList<string> source)
        {
            FileLines = source.ToArray();
            for (var i = 0; i < source.Count; i++)
            {
                var line = source[i];
                if (!line.Contains("if(")) continue;
                source[i] = "";
                var openBarakCount = 0;
                for (var subIndex = i; subIndex < source.Count; subIndex++)
                {
                    if (source[subIndex].Trim() == "{")
                    {
                        source[subIndex] = "";
                        openBarakCount++;
                    }
                    if (source[subIndex].Trim() == "}")
                    {
                        source[subIndex] = "";
                        openBarakCount--;
                        if (openBarakCount <= 0)
                            break;
                    }
                    if (source[subIndex].Trim() == "continue;")
                        source[subIndex] = "";
                    if (source[subIndex].Trim() == "return;")
                        source[subIndex] = "";
                    if (RegularExpression.GetRegex(RegexEnum.ThrowError).Match(source[subIndex]).Success)
                        source[subIndex] = "";
                }
            }
            foreach (var line in source)
                if (line.Trim() != "")
                    FileToTranslate += line + (char) 10;
        }
    }
}