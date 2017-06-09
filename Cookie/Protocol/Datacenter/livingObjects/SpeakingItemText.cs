

// Generated on 12/06/2016 11:35:51
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("SpeakingItemsText")]
    public class SpeakingItemText : IDataObject
    {
        public const String MODULE = "SpeakingItemsText";
        public int TextId;
        public float TextProba;
        public uint TextStringId;
        public int TextLevel;
        public int TextSound;
        public String TextRestriction;
    }
}