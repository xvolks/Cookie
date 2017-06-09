

// Generated on 12/06/2016 11:35:49
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("AlignmentBalance")]
    public class AlignmentBalance : IDataObject
    {
        public const String MODULE = "AlignmentBalance";
        public int Id;
        public int StartValue;
        public int EndValue;
        public uint NameId;
        public uint DescriptionId;
    }
}