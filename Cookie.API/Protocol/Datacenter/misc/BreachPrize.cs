using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("BreachPrize")]
    public class BreachPrize : IDataObject
    {
		private const string MODULE = "BreachPrize";
		public int Id;
		public int NameId;
		public int CategoryId;
		public int Currency;
		public string TooltipKey;
		public int DescriptionKey;
		public int ItemId;
    }
}
