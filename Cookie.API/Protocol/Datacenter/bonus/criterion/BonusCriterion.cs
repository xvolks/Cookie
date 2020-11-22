using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("BonusCriterion")]
    public class BonusCriterion : IDataObject
    {
		private const string MODULE = "BonusCriterion";
		public int Id;
		public uint Type;
		public int Value;
    }
}
