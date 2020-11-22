using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("CensoredContent")]
    public class CensoredContent : IDataObject
    {
		private const string MODULE = "CensoredContent";
		public string Lang;
		public int Type;
		public int OldValue;
		public int NewValue;
    }
}
