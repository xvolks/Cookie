// Generated on 12/06/2016 11:35:50

using System.Collections.Generic;
using Cookie.API.Gamedata.D2o;

namespace Cookie.API.Datacenter
{
    [D2oClass("Idols")]
    public class Idol : IDataObject
    {
        public const string MODULE = "Idols";
        public int CategoryId;
        public string Description;
        public int DropBonus;
        public int ExperienceBonus;
        public bool GroupOnly;
        public int Id;
        public List<int> IncompatibleMonsters;
        public int ItemId;
        public int Score;
        public int SpellPairId;
        public List<float> SynergyIdolsCoeff;
        public List<int> SynergyIdolsIds;
    }
}