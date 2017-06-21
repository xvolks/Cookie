using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("AbuseReasons")]
    public class AbuseReasons : IDataObject
    {
        public const string MODULE = "AbuseReasons";
        public uint AbuseReasonId;
        public uint Mask;
        public int ReasonTextId;
    }
}