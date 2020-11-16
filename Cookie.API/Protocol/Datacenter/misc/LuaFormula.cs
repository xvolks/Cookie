using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("LuaFormula")]
    public class LuaFormula : IDataObject
    {
		private const string MODULE = "LuaFormula";
		public int Id;
		public string FormulaName;
		public string luaFormula;
    }
}
