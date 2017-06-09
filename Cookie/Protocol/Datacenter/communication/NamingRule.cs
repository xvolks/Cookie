namespace Cookie.Datacenter
{
    using Cookie.Gamedata.D2o;
    using System;

    [D2oClass("NamingRule")]
    public class NamingRule : IDataObject
    {
        public const String MODULE = "Smileys";
        public uint Id;
        public uint MinLength;
        public uint MaxLength;
        public string Regexp;
    }
}
