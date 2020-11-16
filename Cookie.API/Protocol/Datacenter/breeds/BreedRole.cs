using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("BreedRole")]
    public class BreedRole : IDataObject
    {
		private const string MODULE = "BreedRole";
		public int Id;
		public int NameId;
		public int DescriptionId;
		public int AssetId;
		public int Color;
    }
}
