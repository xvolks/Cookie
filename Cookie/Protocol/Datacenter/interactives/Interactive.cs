

// Generated on 12/06/2016 11:35:50
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("Interactives")]
    public class Interactive : IDataObject
    {
        public const String MODULE = "Interactives";
        public int Id;
        public uint NameId;
        public int ActionId;
        public Boolean DisplayTooltip;
    }
}