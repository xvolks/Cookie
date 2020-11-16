using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("HavenbagTheme")]
    public class HavenbagTheme : IDataObject
    {
		private const string MODULE = "HavenbagTheme";
		public int Id;
		public int NameId;
		public int MapId;
    }
}
