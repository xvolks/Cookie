// Generated on 12/06/2016 11:35:52

using System.Collections.Generic;
using Cookie.API.Gamedata.D2o;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("SubAreas")]
    public class SubArea : IDataObject
    {
        public const string MODULE = "SubAreas";
        public List<uint> Achievements;
        public List<AmbientSound> AmbientSounds;
        public int AreaId;
        public bool BasicAccountAllowed;
        public Rectangle Bounds;
        public bool Capturable;
        public List<uint> CustomWorldMap;
        public bool DisplayOnWorldMap;
        public List<uint> EntranceMapIds;
        public List<uint> ExitMapIds;
        public int ExploreAchievementId;
        public List<int> Harvestables;
        public int Id;
        public bool IsConquestVillage;
        public bool IsDiscovered;
        public uint Level;
        public List<uint> MapIds;
        public List<uint> Monsters;
        public uint NameId;
        public List<List<int>> Npcs;
        public int PackId;
        public List<List<int>> Playlists;
        public List<List<int>> Quests;
        public List<int> Shape;
    }
}