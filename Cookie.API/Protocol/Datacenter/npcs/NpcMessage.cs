using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("NpcMessage")]
    public class NpcMessage : IDataObject
    {
		private const string MODULE = "NpcMessage";
		public int Id;
		public int MessageId;
		public List<string> MessageParams;
    }
}
