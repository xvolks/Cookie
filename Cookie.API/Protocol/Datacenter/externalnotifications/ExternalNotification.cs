// Generated on 12/06/2016 11:35:50

using Cookie.API.Gamedata.D2o;

namespace Cookie.API.Datacenter
{
    [D2oClass("ExternalNotifications")]
    public class ExternalNotification : IDataObject
    {
        public const string MODULE = "ExternalNotifications";
        public int CategoryId;
        public int ColorId;
        public bool DefaultEnable;
        public bool DefaultMultiAccount;
        public bool DefaultNotify;
        public bool DefaultSound;
        public uint DescriptionId;
        public int IconId;
        public int Id;
        public uint MessageId;
        public string Name;
    }
}