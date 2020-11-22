using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("ServerCommunity")]
    public class ServerCommunity : IDataObject
    {
		private const string MODULE = "ServerCommunity";
		public int Id;
		public int NameId;
		public List<string> DefaultCountries;
		public string ShortId;
		public List<int> SupportedLangIds;
		public int NamingRulePlayerNameId;
		public int NamingRuleGuildNameId;
		public int NamingRuleAllianceNameId;
		public int NamingRuleAllianceTagId;
		public int NamingRulePartyNameId;
		public int NamingRuleMountNameId;
		public int NamingRuleNameGeneratorId;
		public int NamingRuleAdminId;
		public int NamingRuleModoId;
    }
}
