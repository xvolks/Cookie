

// Generated on 12/06/2016 11:35:51
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("Notifications")]
    public class Notification : IDataObject
    {
        public const String MODULE = "Notifications";
        public int Id;
        public uint TitleId;
        public uint MessageId;
        public int IconId;
        public int TypeId;
        public String Trigger;
    }
}