

// Generated on 12/06/2016 11:35:50
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("Emoticons")]
    public class Emoticon : IDataObject
    {
        public const String MODULE = "Emoticons";
        public uint Id;
        public uint NameId;
        public uint ShortcutId;
        public uint Order;
        public String DefaultAnim;
        public Boolean Persistancy;
        public Boolean Eightdirections;
        public Boolean Aura;
        public List<String> Anims;
        public uint Cooldown = 1000;
        public uint Duration = 0;
        public uint Weight;
        public uint SpellLevelId;
    }
}