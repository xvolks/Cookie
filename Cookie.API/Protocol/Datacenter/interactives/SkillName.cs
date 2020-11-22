using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("SkillName")]
    public class SkillName : IDataObject
    {
		private const string MODULE = "SkillName";
		public int Id;
		public int NameId;
    }
}
