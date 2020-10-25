

// Generated on 12/06/2016 11:35:52
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("Spells")]
    public class Spell : IDataObject
    {
        public const String MODULE = "Spells";
        public int Id;
        public uint NameId;
        public uint DescriptionId;
        public uint TypeId;
        public uint Order;
        public String ScriptParams;
        public String ScriptParamsCritical;
        public int ScriptId;
        public int ScriptIdCritical;
        public int IconId;
        public List<uint> SpellLevels;
        public List<int> Variants;
        public Boolean UseParamCache = true;
        public Boolean Verbosecast;
        public uint ObtentionLevel;
        public Boolean UseSpellLevelScaling;
        public String Defaultzone;
        public Boolean BypassSummoningLimit;
        public Boolean CanAlwaysTriggerSpells;
    }
}