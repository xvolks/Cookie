

// Generated on 12/06/2016 11:35:50
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("ItemTypes")]
    public class ItemType : IDataObject
    {
        public const String MODULE = "ItemTypes";
        public int Id;
        public uint NameId;
        public uint SuperTypeId;
        public Boolean Plural;
        public uint Gender;
        public String RawZone;
        public Boolean Mimickable;
        public int CraftXpRatio;
        public int CategoryId;
        public Boolean IsInEncyclopedia;
        public int EvolutiveTypeId;
    }
}