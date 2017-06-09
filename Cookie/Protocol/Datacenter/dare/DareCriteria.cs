

// Generated on 12/06/2016 11:35:50
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("DareCriterias")]
    public class DareCriteria : IDataObject
    {
        public const String MODULE = "DareCriterias";
        public uint Id;
        public uint NameId;
        public uint MaxOccurence;
        public uint MaxParameters;
        public int MinParameterBound;
        public int MaxParameterBound;
    }
}