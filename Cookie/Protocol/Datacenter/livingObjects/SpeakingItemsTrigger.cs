

// Generated on 12/06/2016 11:35:51
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("SpeakingItemsTriggers")]
    public class SpeakingItemsTrigger : IDataObject
    {
        public const String MODULE = "SpeakingItemsTriggers";
        public int TriggersId;
        public List<int> TextIds;
        public List<int> States;
    }
}