using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("Idol")]
    public class Idol : IDataObject
    {
		private const string MODULE = "Idol";
		public int Id;
		public string Description;
		public int CategoryId;
		public int ItemId;
		public bool GroupOnly;
		public int Score;
		public int ExperienceBonus;
		public int DropBonus;
		public int SpellPairId;
		public List<int> SynergyIdolsIds;
		public List<double> SynergyIdolsCoeff;
		public List<int> IncompatibleMonsters;
    }
}
