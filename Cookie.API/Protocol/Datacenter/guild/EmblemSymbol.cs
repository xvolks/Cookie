using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("EmblemSymbol")]
    public class EmblemSymbol : IDataObject
    {
		private const string MODULE = "EmblemSymbol";
		public int Id;
		public int SkinId;
		public int IconId;
		public int Order;
		public int CategoryId;
		public bool Colorizable;
    }
}
