using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("Breeds")]
    public class Breed : IDataObject
    {
        public const String MODULE = "Breeds";
        public int Id;
        public uint ShortNameId;
        public uint LongNameId;
        public uint DescriptionId;
        public uint GameplayDescriptionId;
        public String MaleLook;
        public String FemaleLook;
        public uint CreatureBonesId;
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
        public uint SpawnMap;
        public uint Complexity;
        public uint SortIndex;
    }
}