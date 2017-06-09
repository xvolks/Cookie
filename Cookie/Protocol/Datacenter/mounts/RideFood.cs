namespace Cookie.Datacenter
{
    using Cookie.Gamedata.D2o;
    using System;


    [D2oClass("RideFood")]
    public class RideFood : IDataObject
    {
        public const String MODULE = "RideFood";
        public uint Gid;
        public uint TypeId;
    }
}
