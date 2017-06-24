using Cookie.API.Gamedata.D2o;

namespace Cookie.API.Datacenter
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