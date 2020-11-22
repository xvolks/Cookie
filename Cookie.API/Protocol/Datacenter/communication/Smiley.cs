using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("Smiley")]
    public class Smiley : IDataObject
    {
		private const string MODULE = "Smiley";
		public int Id;
		public int Order;
		public string GfxId;
		public bool ForPlayers;
		public List<string> Triggers;
		public int ReferenceId;
		public int CategoryId;
    }
}
