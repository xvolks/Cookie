using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("Skill")]
    public class Skill : IDataObject
    {
		private const string MODULE = "Skill";
		public int Id;
		public int NameId;
		public int ParentJobId;
		public bool IsForgemagus;
		public List<int> ModifiableItemTypeIds;
		public int GatheredRessourceItem;
		public List<int> CraftableItemIds;
		public int InteractiveId;
		public int Range;
		public bool UseRangeInClient;
		public string UseAnimation;
		public int Cursor;
		public int ElementActionId;
		public bool AvailableInHouse;
		public bool ClientDisplay;
		public int LevelMin;
    }
}
