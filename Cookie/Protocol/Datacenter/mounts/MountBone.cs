using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("MountBone")]
    public class MountBone : IDataObject
    {
        public const string MODULE = "MountBone";
        public uint Id;
    }
}