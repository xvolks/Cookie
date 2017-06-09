

// Generated on 12/06/2016 11:35:50
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("ItemSets")]
    public class ItemSet : IDataObject
    {
        public const String MODULE = "ItemSets";
        public uint Id;
        public List<uint> Items;
        public uint NameId;
        public List<List<EffectInstance>> Effects;
        public Boolean BonusIsSecret;
    }
}