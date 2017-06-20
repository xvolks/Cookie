

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
        public bool SelectableByPlayer;
        public string RulesId;
        public string DescriptionId;
    }
}