using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace D2oReader
{
    public class JsonUnpacker
    {
        StringBuilder jsonBuilder;
        JToken unpackedJson;
        Dictionary<int, int> objectPointerTable;
        D2OReader reader;
        Dictionary<int, GameDataClassDefinition> classDefinitions;

        public JsonUnpacker(D2OReader reader, Dictionary<int,int> objectPointerTable, Dictionary<int, GameDataClassDefinition> classDefinitions)
        {
            this.reader = reader;
            this.objectPointerTable = objectPointerTable;
            this.classDefinitions = classDefinitions;

            jsonBuilder = new StringBuilder();
        }

        public void Unpack()
        {
            buildJsonString();
        }

        public void WriteIndentedJson(string shouldWrite)
        {
            if (IsValidJson)
            {
                System.IO.Directory.CreateDirectory(@".\output\");
                using (TextWriter writer = new StreamWriter(String.Format(@".\output\{0}.json", Path.GetFileNameWithoutExtension(shouldWrite))))
                {
                    writer.Write(unpackedJson.ToString(Formatting.Indented));
                }
            }
        }

        public void WriteJson()
        {
            if (IsValidJson)
            {
                using (TextWriter writer = new StreamWriter(@".\output.json"))
                {
                    writer.Write(unpackedJson.ToString(Formatting.None));
                }
            }
        }

        private void buildJsonString()
        {
            addArrayOpenBracket();
            addObjects();
            addArrayCloseBracket();
        }

        public bool IsValidJson
        {
            get
            {
                try
                {
                    unpackedJson = JToken.Parse(jsonBuilder.ToString());
                    return true;
                }
                catch (JsonReaderException exception)
                {
                    Console.WriteLine("Json output is invalid:");
                    Console.WriteLine(exception.Message);
                    return false;
                }
            }
            
        }

        private void addObjects()
        {
            int[] indexTableKeys = objectPointerTable.Keys.ToArray<int>();

            for (int i = 0; i < indexTableKeys.Length; i++)
            {
                jsonBuilder.Append(getObjectJsonString(indexTableKeys[i]))
                    .Append(writeCommaIfHasMore(indexTableKeys.Length, i))
                    .AppendLine();
            }
        }
        private static string writeCommaIfHasMore(int count, int i)
        {
            if (hasMoreElement(count, i))
                return ",";
            else
                return String.Empty;
        }

        private static bool hasMoreElement(int count, int i)
        {
            return i != count - 1;
        }

        public string getObjectJsonString(int objectId)
        {
            int objectPointer = objectPointerTable[objectId];
            reader.Pointer = objectPointer;

            int objectClassId = reader.ReadInt();

            StringBuilder objectBuilder = new StringBuilder();

            objectBuilder.Append(getObjectBuilder(objectClassId));

            return objectBuilder.ToString();
        }

        private string getObjectBuilder(int classId)
        {
            GameDataClassDefinition classDefinition = classDefinitions[classId];
            return getFieldsBuilder(classDefinition);
        }
        private string getFieldsBuilder(GameDataClassDefinition classDefinition)
        {
            StringBuilder fieldsBuilder = new StringBuilder();
            int numberOfFields = classDefinition.Fields.Count;
            fieldsBuilder.AppendLine("{");
            for (int i = 0; i < numberOfFields; i++)
            {
                fieldsBuilder
                    .Append(getFieldBuilder(classDefinition.Fields[i]))
                    .Append(writeCommaIfHasMore(numberOfFields, i))
                    .AppendLine();
            }
            fieldsBuilder.Append("}");

            return fieldsBuilder.ToString();
        }
        private string getFieldBuilder(GameDataField field)
        {
            StringBuilder fieldBuilder = new StringBuilder();

            fieldBuilder
                .Append(JsonConvert.ToString(field.fieldName))
                .Append(": ")
                .Append(getFieldValueBuilder(field));

            return fieldBuilder.ToString();
        }
        private string getFieldValueBuilder(GameDataField field)
        {
            StringBuilder fieldValueBuilder = new StringBuilder();

            switch (field.fieldType)
            {
                case GameDataTypeEnum.Vector:
                    fieldValueBuilder.Append("[");
                    int vectorLength = reader.ReadInt();

                    for (int i = 0; i < vectorLength; i++)
                    {
                        fieldValueBuilder
                            .Append(getFieldValueBuilder(field.innerField))
                            .Append(writeCommaIfHasMore(vectorLength, i));
                    }

                    fieldValueBuilder.Append("]");
                    break;
                case GameDataTypeEnum.Int:
                    fieldValueBuilder.Append(reader.ReadInt());
                    break;
                case GameDataTypeEnum.UInt:
                    fieldValueBuilder.Append(reader.ReadUInt());
                    break;
                case GameDataTypeEnum.I18N:
                    fieldValueBuilder.Append(reader.ReadInt());
                    break;
                case GameDataTypeEnum.String:
                    fieldValueBuilder.Append(JsonConvert.ToString(reader.ReadUtf8()));
                    break;
                case GameDataTypeEnum.Bool:
                    fieldValueBuilder.Append(JsonConvert.ToString(reader.ReadBool())); //in json bool is true/false not True/False
                    break;
                case GameDataTypeEnum.Double:
                    fieldValueBuilder.Append(JsonConvert.ToString(reader.ReadDouble())); //handling the "," vs "." problem of the culture specifics
                    break;
                default:
                    if (field.fieldType > 0) //if type is an object
                    {
                        int classId = reader.ReadInt();
                        if (classDefinitions.ContainsKey(classId))
                        {
                            fieldValueBuilder.Append(getObjectBuilder(classId));
                        }
                    }
                    else
                    {
                        Console.WriteLine("Error: invalid type( {0} ) for field {1}", field.fieldType, field.fieldName);
                    }
                    break;
            }
            return fieldValueBuilder.ToString();
        }
        private void addArrayCloseBracket()
        {
            jsonBuilder.Append("]");
        }

        private void addArrayOpenBracket()
        {
            jsonBuilder.Append("[");
        }
    }
}