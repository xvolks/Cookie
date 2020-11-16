using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("BonusEquippedItemCriterion")]
    public class BonusEquippedItemCriterion : IDataObject
    {
		private const string MODULE = "BonusEquippedItemCriterion";
		public int Id;
		public uint Type;
		public int Value;
    }
}
