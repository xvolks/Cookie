using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("Head")]
    public class Head : IDataObject
    {
		private const string MODULE = "Head";
		public int Id;
		public string Skins;
		public string AssetId;
		public int Breed;
		public int Gender;
		public string Label;
		public int Order;
    }
}
