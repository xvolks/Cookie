

// Generated on 12/06/2016 11:35:50
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("IncarnationLevels")]
    public class IncarnationLevel : IDataObject
    {
        public const String MODULE = "IncarnationLevels";
        public int Id;
        public int IncarnationId;
        public int Level;
        public uint RequiredXp;
    }
}