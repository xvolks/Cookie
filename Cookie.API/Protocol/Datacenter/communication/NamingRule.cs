using Cookie.API.Gamedata.D2o;

namespace Cookie.API.Datacenter
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