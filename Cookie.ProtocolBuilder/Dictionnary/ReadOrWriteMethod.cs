using System.Collections.Generic;

namespace Cookie.ProtocolBuilder.Dictionnary
{
    public class ReadOrWriteMethod : Dictionary<string, string>
    {
        public static ReadOrWriteMethod Singleton = new ReadOrWriteMethod();

        public ReadOrWriteMethod()
        {
            Add("boolean", "Boolean");
            Add("byte", "Byte");
            Add("double", "Double");
            Add("float", "Float");
            Add("int", "Int");
            Add("short", "Short");
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

        public static string GetReadMethode(string key, string regex)
        {
            key = key.ToLower();
            key = key.Replace(regex, "");
            return "Read" + Singleton[key];
        }

        public static string GetWriteMethode(string key, string regex)
        {
            key = key.ToLower();
            key = key.Replace(regex, "");
            return "Write" + Singleton[key];
        }
    }
}