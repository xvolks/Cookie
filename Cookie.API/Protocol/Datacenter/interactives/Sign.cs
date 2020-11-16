using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("Sign")]
    public class Sign : IDataObject
    {
		private const string MODULE = "Sign";
		public int Id;
		public string Params;
		public int SkillId;
		public int TextKey;
    }
}
