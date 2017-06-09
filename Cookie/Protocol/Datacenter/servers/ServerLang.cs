namespace Cookie.Datacenter
{
    using Cookie.Gamedata.D2o;
    using System;


    [D2oClass("ServerLang")]
    public class ServerLang : IDataObject
    {
        public const String MODULE = "ServerLang";
        public int Id;
        public uint NameId;
        public string LangCode;
    }
}
