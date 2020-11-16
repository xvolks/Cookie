using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("SkinMapping")]
    public class SkinMapping : IDataObject
    {
		private const string MODULE = "SkinMapping";
		public int Id;
		public int LowDefId;
    }
}
