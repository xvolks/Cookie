using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("IncarnationLevel")]
    public class IncarnationLevel : IDataObject
    {
		private const string MODULE = "IncarnationLevel";
		public int Id;
		public int IncarnationId;
		public int Level;
		public int RequiredXp;
    }
}
