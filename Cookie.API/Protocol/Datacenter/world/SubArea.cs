using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("SubArea")]
    public class SubArea : IDataObject
    {
		private const string MODULE = "SubArea";
		public int Id;
		public int NameId;
		public int AreaId;
		public List<AmbientSound> AmbientSounds;
		public List<List<int>> Playlists;
		public List<double> MapIds;
		public Rectangle Bounds;
		public List<int> Shape;
		public List<uint> CustomWorldMap;
		public uint PackId;
		public uint Level;
		public bool IsConquestVillage;
		public bool BasicAccountAllowed;
		public bool DisplayOnWorldMap;
		public bool MountAutoTripAllowed;
		public bool PsiAllowed;
		public List<uint> Monsters;
		public List<double> EntranceMapIds;
		public List<double> ExitMapIds;
		public bool Capturable;
		public List<uint> Achievements;
		public List<List<double>> Quests;
		public List<List<double>> Npcs;
		public int ExploreAchievementId;
		public List<int> Harvestables;
		public int AssociatedZaapMapId;
    }
}
