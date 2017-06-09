namespace Cookie.Datacenter
{
    using Cookie.Gamedata.D2o;
    using System;

    [D2oClass("MountBone")]
    public class MountBone : IDataObject
    {
        public const String MODULE = "MountBone";
        public uint Id;
    }
}
