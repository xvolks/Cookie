// Generated on 12/06/2016 11:35:52

using System.Collections.Generic;
using Cookie.API.Gamedata.D2o;

namespace Cookie.API.Datacenter
{
    [D2oClass("Spells")]
    public class Spell : IDataObject
    {
        public const string MODULE = "Spells";
        public uint DescriptionId;
        public int IconId;
        public int Id;
        public uint NameId;
        public uint ObtentionLevel;
        public uint Order;
        public int ScriptId;
        public int ScriptIdCritical;
        public string ScriptParams;
        public string ScriptParamsCritical;
        public List<uint> SpellLevels;
        public uint TypeId;
        public bool UseParamCache = true;
        public bool UseSpellLevelScaling;
        public List<int> Variants;
        public bool Verbosecast;
    }
}