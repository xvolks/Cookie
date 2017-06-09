

// Generated on 12/06/2016 11:35:51
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("CensoredContents")]
    public class CensoredContent : IDataObject
    {
        public const String MODULE = "CensoredContents";
        public int Type;
        public int OldValue;
        public int NewValue;
        public String Lang;
    }
}