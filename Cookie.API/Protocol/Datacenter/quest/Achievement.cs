using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("Achievement")]
    public class Achievement : IDataObject
    {
		private const string MODULE = "Achievement";
		public int Id;
		public int NameId;
		public int CategoryId;
		public int DescriptionId;
		public int IconId;
		public int Points;
		public int Level;
		public int Order;
		public bool AccountLinked;
		public List<int> ObjectiveIds;
		public List<int> RewardIds;
    }
}
