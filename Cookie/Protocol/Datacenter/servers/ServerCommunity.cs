

// Generated on 12/06/2016 11:35:52
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("ServerCommunities")]
    public class ServerCommunity : IDataObject
    {
        public const String MODULE = "ServerCommunities";
        public int Id;
        public uint NameId;
        public string ShortId;
        public List<String> DefaultCountries;
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