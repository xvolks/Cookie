// Generated on 12/06/2016 11:35:50

using System.Collections.Generic;
using Cookie.API.Gamedata.D2o;

namespace Cookie.API.Datacenter
{
    [D2oClass("Emoticons")]
    public class Emoticon : IDataObject
    {
        public const string MODULE = "Emoticons";
        public List<string> Anims;
        public bool Aura;
        public uint Cooldown = 1000;
        public string DefaultAnim;
        public uint Duration = 0;
        public bool Eightdirections;
        public uint Id;
        public uint NameId;
        public uint Order;
        public bool Persistancy;
        public uint ShortcutId;
        public uint SpellLevelId;
        public uint Weight;
    }
}