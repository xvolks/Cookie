using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("MountFamily")]
    public class MountFamily : IDataObject
    {
        public const string MODULE = "MountFamily";
        public string HeadUri;
        public uint Id;
        public uint NameId;
    }
}