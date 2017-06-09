

// Generated on 12/06/2016 11:35:50
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("Houses")]
    public class House : IDataObject
    {
        public const String MODULE = "Houses";
        public int TypeId;
        public uint DefaultPrice;
        public int NameId;
        public int DescriptionId;
        public int GfxId;
    }
}