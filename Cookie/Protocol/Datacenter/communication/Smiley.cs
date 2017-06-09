

// Generated on 12/06/2016 11:35:50
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("Smileys")]
    public class Smiley : IDataObject
    {
        public const String MODULE = "Smileys";
        public uint Id;
        public uint Order;
        public String GfxId;
        public Boolean ForPlayers;
        public List<String> Triggers;
        public uint ReferenceId;
        public uint CategoryId;
    }
}