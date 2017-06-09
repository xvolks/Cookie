

// Generated on 12/06/2016 11:35:50
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("SmileyCategories")]
    public class SmileyCategory : IDataObject
    {
        public const String MODULE = "SmileyCategories";
        public int Id;
        public uint Order;
        public String GfxId;
        public Boolean IsFake;
    }
}