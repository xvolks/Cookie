

// Generated on 12/06/2016 11:35:52
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("ServerPopulations")]
    public class ServerPopulation : IDataObject
    {
        public const String MODULE = "ServerPopulations";
        public int Id;
        public uint NameId;
        public int Weight;
    }
}