using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("BonusQuestCategoryCriterion")]
    public class BonusQuestCategoryCriterion : IDataObject
    {
		private const string MODULE = "BonusQuestCategoryCriterion";
		public int Id;
		public uint Type;
		public int Value;
    }
}
