namespace Cookie.Datacenter
{
    using Cookie.Gamedata.D2o;
    using System;


    [D2oClass("MountFamily")]
    public class MountFamily : IDataObject
    {
        public const String MODULE = "MountFamily";
        public uint Id;
        public uint NameId;
        public string HeadUri;
    }
}
