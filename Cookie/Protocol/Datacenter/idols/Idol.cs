

// Generated on 12/06/2016 11:35:50
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("Idols")]
    public class Idol : IDataObject
    {
        public const String MODULE = "Idols";
        public int Id;
        public String Description;
        public int CategoryId;
        public int ItemId;
        public Boolean GroupOnly;
        public int SpellPairId;
        public int Score;
        public int ExperienceBonus;
        public int DropBonus;
        public List<int> SynergyIdolsIds;
        public List<float> SynergyIdolsCoeff;
        public List<int> IncompatibleMonsters;
    }
}