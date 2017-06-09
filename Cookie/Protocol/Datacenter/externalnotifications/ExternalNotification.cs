

// Generated on 12/06/2016 11:35:50
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("ExternalNotifications")]
    public class ExternalNotification : IDataObject
    {
        public const String MODULE = "ExternalNotifications";
        public int Id;
        public int CategoryId;
        public int IconId;
        public int ColorId;
        public uint DescriptionId;
        public Boolean DefaultEnable;
        public Boolean DefaultSound;
        public Boolean DefaultNotify;
        public Boolean DefaultMultiAccount;
        public String Name;
        public uint MessageId;
    }
}