using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("Recipe")]
    public class Recipe : IDataObject
    {
		private const string MODULE = "Recipe";
		public int ResultId;
		public int ResultNameId;
		public uint ResultTypeId;
		public uint ResultLevel;
		public List<int> IngredientIds;
		public List<uint> Quantities;
		public int JobId;
		public int SkillId;
		public int Order;
    }
}
