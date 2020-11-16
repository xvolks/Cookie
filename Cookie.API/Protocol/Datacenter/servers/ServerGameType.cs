using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("ServerGameType")]
    public class ServerGameType : IDataObject
    {
		private const string MODULE = "ServerGameType";
		public int Id;
		public bool SelectableByPlayer;
		public int NameId;
		public int RulesId;
		public int DescriptionId;
    }
}
