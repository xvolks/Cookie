

// Generated on 12/06/2016 11:35:52
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("ServerGameTypes")]
    public class ServerGameType : IDataObject
    {
        public const String MODULE = "ServerGameTypes";
        public int Id;
        public uint NameId;
        public Boolean SelectableByPlayer;
        public Cookie.Gamedata.I18n.I18nDataManager RulesId;
        public Cookie.Gamedata.I18n.I18nDataManager DescriptionId;
    }
}