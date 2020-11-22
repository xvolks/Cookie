using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("Server")]
    public class Server : IDataObject
    {
		private const string MODULE = "Server";
		public int Id;
		public int NameId;
		public int CommentId;
		public double OpeningDate;
		public string Language;
		public int PopulationId;
		public int GameTypeId;
		public int CommunityId;
		public List<string> RestrictedToLanguages;
		public bool MonoAccount;
    }
}
