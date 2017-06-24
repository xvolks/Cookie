using Cookie.API.Gamedata.D2o;

namespace Cookie.API.Datacenter
{
    [D2oClass("MountBone")]
    public class MountBone : IDataObject
    {
        public const string MODULE = "MountBone";
        public uint Id;
    }
}