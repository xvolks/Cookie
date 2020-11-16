using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("Breed")]
    public class Breed : IDataObject
    {
		private const string MODULE = "Breed";
		public int Id;
		public int ShortNameId;
		public int LongNameId;
		public int DescriptionId;
		public int GameplayDescriptionId;
		public string MaleLook;
		public string FemaleLook;
		public int CreatureBonesId;
		public int MaleArtwork;
		public int FemaleArtwork;
		public List<List<uint>> StatsPointsForStrength;
		public List<List<uint>> StatsPointsForIntelligence;
		public List<List<uint>> StatsPointsForChance;
		public List<List<uint>> StatsPointsForAgility;
		public List<List<uint>> StatsPointsForVitality;
		public List<List<uint>> StatsPointsForWisdom;
		public List<uint> BreedSpellsId;
		public List<BreedRoleByBreed> BreedRoles;
		public List<uint> MaleColors;
		public List<uint> FemaleColors;
		public int SpawnMap;
		public int Complexity;
		public int SortIndex;
    }
}
