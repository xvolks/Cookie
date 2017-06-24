using System.Collections.Generic;
using Cookie.API.Gamedata.D2o;

namespace Cookie.API.Datacenter
{
    [D2oClass("Breeds")]
    public class Breed : IDataObject
    {
        public const string MODULE = "Breeds";
        public List<BreedRoleByBreed> BreedRoles;
        public List<uint> BreedSpellsId;
        public uint Complexity;
        public uint CreatureBonesId;
        public uint DescriptionId;
        public int FemaleArtwork;
        public List<uint> FemaleColors;
        public string FemaleLook;
        public uint GameplayDescriptionId;
        public int Id;
        public uint LongNameId;
        public int MaleArtwork;
        public List<uint> MaleColors;
        public string MaleLook;
        public uint ShortNameId;
        public uint SortIndex;
        public uint SpawnMap;
        public List<List<uint>> StatsPointsForAgility;
        public List<List<uint>> StatsPointsForChance;
        public List<List<uint>> StatsPointsForIntelligence;
        public List<List<uint>> StatsPointsForStrength;
        public List<List<uint>> StatsPointsForVitality;
        public List<List<uint>> StatsPointsForWisdom;
    }
}