// Generated on 12/06/2016 11:35:52
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("Spirits")]
    public class Spirits : IDataObject
    {
        public const String MODULE = "Spirits";
        public int Id;
        public int Nameid;
        public int Characteristic;
        public List<int> ItemIds;
    }
}
