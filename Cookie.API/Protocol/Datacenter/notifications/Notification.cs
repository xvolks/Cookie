// Generated on 12/06/2016 11:35:51

using Cookie.API.Gamedata.D2o;

namespace Cookie.API.Datacenter
{
    [D2oClass("Notifications")]
    public class Notification : IDataObject
    {
        public const string MODULE = "Notifications";
        public int IconId;
        public int Id;
        public uint MessageId;
        public uint TitleId;
        public string Trigger;
        public int TypeId;
    }
}