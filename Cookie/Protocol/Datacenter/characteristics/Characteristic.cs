

// Generated on 12/06/2016 11:35:50
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("Characteristics")]
    public class Characteristic : IDataObject
    {
        public const String MODULE = "Characteristics";
        public int Id;
        public String Keyword;
        public uint NameId;
        public String Asset;
        public int CategoryId;
        public Boolean Visible;
        public int Order;
        public Boolean Upgradable;
    }
}