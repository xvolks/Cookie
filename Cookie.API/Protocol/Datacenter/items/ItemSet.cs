// Generated on 12/06/2016 11:35:50

using System.Collections.Generic;
using Cookie.API.Gamedata.D2o;

namespace Cookie.API.Datacenter
{
    [D2oClass("ItemSets")]
    public class ItemSet : IDataObject
    {
        public const string MODULE = "ItemSets";
        public bool BonusIsSecret;
        public List<List<EffectInstance>> Effects;
        public uint Id;
        public List<uint> Items;
        public uint NameId;
    }
}