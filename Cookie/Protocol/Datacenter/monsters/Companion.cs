

// Generated on 12/06/2016 11:35:51
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("Companions")]
    public class Companion : IDataObject
    {
        public const String MODULE = "Companions";
        public int Id;
        public uint NameId;
        public String Look;
        public Boolean WebDisplay;
        public uint DescriptionId;
        public uint StartingSpellLevelId;
        public uint AssetId;
        public List<uint> Characteristics;
        public List<uint> Spells;
        public int CreatureBoneId;
    }
}