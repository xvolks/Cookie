using System.Collections.Generic;

namespace Cookie.ProtocolBuilder.Dictionnary
{
    public class ReadVectorField : Dictionary<string, string>
    {
        public static ReadVectorField Singleton = new ReadVectorField();

        public ReadVectorField()
        {
            Add("boolean", "Boolean");
            Add("byte", "Byte");
            Add("double", "Double");
            Add("float", "Float");
            Add("int", "Int");
            Add("short", "UShort");
            Add("unsignedint", "UInt");
            Add("unsignedshort", "UShort");
            Add("unsignedbyte", "Byte");
            Add("utf", "UTF");
            Add("utfbytes", "UTFBytes");
            Add("string", "UTF");
            Add("uint", "UInt");
            Add("number", "Double");
            Add("varint", "VarInt");
            Add("varuhint", "VarUhInt");
            Add("varshort", "VarShort");
            Add("varuhshort", "VarUhShort");
            Add("varlong", "VarLong");
            Add("varuhlong", "VarUhLong");
        }

        public static string GetReadMethode(string key)
        {
            key = key.ToLower();
            key = key.Replace("write", "");
            return "Read" + Singleton[key];
        }
    }
}