using Cookie.API.Gamedata.D2o;

namespace Cookie.API.Datacenter
{
    [D2oClass("RideFood")]
    public class RideFood : IDataObject
    {
        public const string MODULE = "RideFood";
        public uint Gid;
        public uint TypeId;
    }
}