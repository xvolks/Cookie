using System.Collections.Generic;

namespace Cookie.ProtocolBuilder.Dictionnary
{
    public class PrimitiveType : Dictionary<string, string>
    {
        public static PrimitiveType Singleton = new PrimitiveType();

        public PrimitiveType()
        {
            Add("boolean", "bool");
            Add("byte", "byte");
            Add("double", "double");
            Add("float", "float");
            Add("int", "int");
            Add("short", "short");
            Add("uint", "uint");
            Add("sbyte", "sbyte");
            Add("ushort", "ushort");
            Add("utf", "string");
            Add("utfbytes", "string");
            Add("string", "string");
            Add("number", "double");
            Add("varuhshort", "ushort");
            Add("varshort", "short");
            Add("varuhint", "uint");
            Add("varint", "int");
            Add("varlong", "long");
            Add("varuhlong", "ulong");
            Add("varushort", "ushort");
        }

        public static string GetTypeByReadMethode(string methode)
        {
            methode = methode.Replace("Read", "");
            return Singleton.ContainsKey(methode.ToLower()) ? Singleton[methode.ToLower()] : null;
        }
    }
}