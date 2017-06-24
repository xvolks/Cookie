using Cookie.API.Gamedata.D2o;

namespace Cookie.API.Datacenter
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