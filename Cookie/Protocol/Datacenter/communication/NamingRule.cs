using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("NamingRule")]
    public class NamingRule : IDataObject
    {
        public const string MODULE = "Smileys";
        public uint Id;
        public uint MaxLength;
        public uint MinLength;
        public string Regexp;
    }
}