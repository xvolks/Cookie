// Generated on 12/06/2016 11:35:52

using System.Collections.Generic;
using Cookie.API.Gamedata.D2o;

namespace Cookie.API.Datacenter
{
    [D2oClass("ServerCommunities")]
    public class ServerCommunity : IDataObject
    {
        public const string MODULE = "ServerCommunities";
        public List<string> DefaultCountries;
        public int Id;
        public uint NameId;
        public int NamingRuleAdminId;
        public int NamingRuleAllianceNameId;
        public int NamingRuleAllianceTagId;
        public int NamingRuleGuildNameId;
        public int NamingRuleModoId;
        public int NamingRuleMountNameId;
        public int NamingRuleNameGeneratorId;
        public int NamingRulePartyNameId;
        public int NamingRulePlayerNameId;
        public string ShortId;
        public List<int> SupportedLangIds;
    }
}