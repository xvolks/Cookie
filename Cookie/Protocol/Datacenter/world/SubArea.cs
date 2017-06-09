

// Generated on 12/06/2016 11:35:52
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;
using Cookie.Datacenter;
using Cookie.GameData.D2O;

namespace Cookie.Datacenter
{
    [D2oClass("SubAreas")]
    public class SubArea : IDataObject
    {
        public const String MODULE = "SubAreas";
        public int Id;
        public uint NameId;
        public int AreaId;
        public List<AmbientSound> AmbientSounds;
        public List<List<int>> Playlists;
        public List<uint> MapIds;
        public Rectangle Bounds;
        public List<int> Shape;
        public List<uint> CustomWorldMap;
        public int PackId;
        public uint Level;
        public Boolean IsConquestVillage;
        public Boolean BasicAccountAllowed;
        public Boolean DisplayOnWorldMap;
        public List<uint> Monsters;
        public List<uint> EntranceMapIds;
        public List<uint> ExitMapIds;
        public Boolean Capturable;
        public List<uint> Achievements;
        public List<List<int>> Quests;
        public List<List<int>> Npcs;
        public int ExploreAchievementId;
        public Boolean IsDiscovered;
        public List<int> Harvestables;
    }
}