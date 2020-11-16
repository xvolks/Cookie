using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace D2oReader
{
    public class App
    {
        int classCount;

        D2OReader reader;
        JsonUnpacker unpacker;
        Dictionary<int, int> objectPointerTable;
        Dictionary<int, GameDataClassDefinition> classDefinitions;
        StreamWriter file;
        int contentOffset = 0; //or uint?

        public App(string d2oFilePath)
        {
            objectPointerTable = new Dictionary<int, int>();
            classDefinitions = new Dictionary<int, GameDataClassDefinition>();

            using (FileStream d2oFile = File.Open(d2oFilePath, FileMode.Open))
            using (reader = new D2OReader(d2oFile))
            {
                string headerString = reader.ReadAscii(3);

                if (!headerString.Equals("D2O"))
                {
                    reader.Pointer = 0;
                    string headers = reader.ReadUtf8();
                    short formatVersion = reader.ReadShort();
                    int len = reader.ReadInt();
                    reader.Pointer = reader.Pointer + len;
                    contentOffset = reader.Pointer;
                    int streamStartIndex = (contentOffset + 7); //or uint?
                    headers = reader.ReadAscii(3);
                    if (!headers.Equals("D2O"))
                    {
                        throw new InvalidDataException("Header doesn't equal the string 'D2O' : Corrupted file");
                    }
                }

                readObjectPointerTable();
                //printObjectPointerTable();
                readClassTable();
                printClassTable(Path.GetFileNameWithoutExtension(d2oFilePath));
                readGameDataProcessor(); //TODO: implement
                //unpackObjectsAsJson();
                //writeJsonFile(d2oFilePath);
                //printAllObjects(); //call after  unpackObjectsAsJson(); 
                //searchObjectById(); //call after  unpackObjectsAsJson(); 


            }
        }

        private void writeJsonFile(string shouldWrite)
        {
            unpacker.WriteIndentedJson(shouldWrite);
            //unpacker.WriteJson();
        }

        private void printAllObjects()
        {
            foreach (var objectPointer in objectPointerTable)
            {
                Console.WriteLine("Class {0}, Object Id {1}:", classDefinitions[getClassId(objectPointer.Key)].Name, objectPointer.Key);
                Console.WriteLine(unpacker.getObjectJsonString(objectPointer.Key));
                Console.WriteLine("Press any key to continue . . .");
                Console.ReadKey();
            }
        }

        private void unpackObjectsAsJson()
        {
            unpacker = new JsonUnpacker(reader,
                objectPointerTable,
                classDefinitions);

            unpacker.Unpack();
        }

        private int getClassId(int objectId)
        {
            int objectPointer = objectPointerTable[objectId];
            reader.Pointer = objectPointer;

            return reader.ReadInt();
        }

        private void searchObjectById()
        {
            int objectId;
            do
            {
                Console.Write("Search object id: ");
                objectId = Int32.Parse(Console.ReadLine());

                if (objectPointerTable.ContainsKey(objectId))
                {
                    Console.WriteLine("Class {0}, Object Id {1}:", classDefinitions[getClassId(objectId)].Name, objectId);
                    Console.WriteLine(unpacker.getObjectJsonString(objectId));
                }
                else
                {
                    Console.WriteLine("Object of id: {0} is not present.", objectId);
                }

            } while (objectId != 0);
        }

        private void printClassTable(string fileName)
        {
            if (classDefinitions.Count > 0)
            {
                //Console.WriteLine("Printing {0} class tables.", classDefinitions.Count);
                //Console.WriteLine("Namespace {0}", fileName);
                foreach (var classDefinition in classDefinitions)
                {

                    
                    int finder = classDefinition.Value.PackageName.IndexOf(".datacenter.");
                    if (finder > 0)
                    {
                        string FolderPath = String.Format("./output/{0}", classDefinition.Value.PackageName.Substring(finder).Replace(".datacenter.", "").Replace(".", "/"));
                        string FilePath = String.Format("{0}/{1}.cs", FolderPath, classDefinition.Value.Name);
                        System.IO.Directory.CreateDirectory(FolderPath);
                        using (StreamWriter newFile = new StreamWriter(FilePath))
                        {
                            newFile.WriteLine("using Cookie.API.Gamedata.D2o;");
                            newFile.WriteLine("using System.Collections.Generic;");
                            newFile.WriteLine("using Cookie.API.Gamedata.D2o.other;");
                            newFile.WriteLine();
                            newFile.WriteLine("namespace Cookie.API.Datacenter");
                            newFile.WriteLine("{");
                            newFile.WriteLine(string.Format("    [D2oClass(\"{0}\")]", classDefinition.Value.Name));
                            newFile.WriteLine(string.Format("    public class {0} : IDataObject", classDefinition.Value.Name));
                            newFile.WriteLine("    {");
                            newFile.WriteLine(string.Format("		private const string MODULE = \"{0}\";", classDefinition.Value.Name));
                            foreach (GameDataField field in classDefinition.Value.Fields)
                            {
                                newFile.WriteLine(string.Format("		{0};", getFieldString(field)));
                            }
                            newFile.WriteLine("    }");
                            newFile.WriteLine("}");
                        }
                    }
                    else
                        Console.WriteLine("ClassId: {0} ClassMemberName: {1} ClassPkgName {2}", classDefinition.Key, classDefinition.Value.Name, classDefinition.Value.PackageName);
                    //Console.WriteLine("[D2oClass(\"{1}\")]", classDefinition.Key,classDefinition.Value.Name);
                    //Console.WriteLine();
                }
            }
        }

        private string getFieldString(GameDataField field)
        {
            StringBuilder fieldBuilder = new StringBuilder();

            fieldBuilder
                .Append("public")
                .Append(" ")
                .Append(getFieldTypeString(field))
                .Append(" ")
                .Append(getFieldNameString(field).Replace("_", "").FirstToUpper());

            return fieldBuilder.ToString();
        }

        private void printField(string fieldString)
        {
            Console.WriteLine(fieldString);
        }
        private List<string> types = new List<string>()
        {
            "UInt",
            "String",
            "Int",
            "I18N",
            "Bool",
            "Double"
        };
        private string getFieldTypeString(GameDataField field, bool isRecall = false)
        {
            if (isPrimitiveFieldType(field))
            {
                string fieldType = getPrimitiveFieldTypeString(field);
                return types.Contains(fieldType) ? fieldType.ToLower().Replace("i18n","int") : fieldType;
            }
            else
            {
                return getCompositeFieldTypeString(field);
            }
        }

        private string getCompositeFieldTypeString(GameDataField field)
        {
            StringBuilder compositeFieldTypeBuilder = new StringBuilder();

            compositeFieldTypeBuilder
                .Append("List")
                .Append("<")
                .Append(getFieldTypeString(field.innerField, true))
                .Append(">");

            return compositeFieldTypeBuilder.ToString();
        }

        private string getPrimitiveFieldTypeString(GameDataField field)
        {
            return field.fieldType > 0 ? classDefinitions[(int)field.fieldType].Name : field.fieldType.ToString();
        }

        private string getFieldNameString(GameDataField field)
        {
            return field.fieldName;
        }

        private static bool isPrimitiveFieldType(GameDataField field)
        {
            return field.innerField == null;
        }

        private void readGameDataProcessor()
        {
            if (reader.BytesAvailable > 0)
            {
                //GameDataProcess(stream);
            };
        }

        private void readClassTable()
        {
            classCount = reader.ReadInt();
            int classId;

            int j = 0;
            while (j < classCount)
            {
                classId = reader.ReadInt();
                readClassDefinition(classId);

                j++;
            }
        }

        private void readClassDefinition(int classId)
        {
            string className = reader.ReadUtf8();
            string packageName = reader.ReadUtf8();
            GameDataClassDefinition classDefinition = new GameDataClassDefinition(packageName, className);
            int fieldsCount = reader.ReadInt();
            uint i=0;
            while(i < fieldsCount)
            {
                classDefinition.AddField(reader);
                i++;
            }
            classDefinitions.Add(classId, classDefinition);
        }

        private void printObjectPointerTable()
        {
            if (objectPointerTable.Count > 0)
            {
                foreach (var objectPointer in objectPointerTable)
                {
                    Console.WriteLine("{0}: {1}", objectPointer.Key, objectPointer.Value);
                }
            }
        }

        private void readObjectPointerTable()
        {
            int tablePointer = reader.ReadInt();
            reader.Pointer =  tablePointer + contentOffset;

            int objectPointerTableLen = reader.ReadInt();

            int key;
            int pointer;

            for (uint i = 0; i < objectPointerTableLen; i += sizeof(int) * 2)
            {
                key = reader.ReadInt();
                pointer = reader.ReadInt();

                objectPointerTable.Add(key, pointer + contentOffset);
            }
        }
    }
    public static class MyExtensions
    {
        public static string FirstToUpper(this string input)
        {
            return (char.ToUpper(input[0]) + input.Substring(1));
        }
    }
}

