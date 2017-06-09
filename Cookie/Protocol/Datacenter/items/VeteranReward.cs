

// Generated on 12/06/2016 11:35:50
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("VeteranRewards")]
    public class VeteranReward : IDataObject
    {
        public const String MODULE = "VeteranRewards";
        public int Id;
        public uint RequiredSubDays;
        public uint ItemGID;
        public uint ItemQuantity;
    }
}