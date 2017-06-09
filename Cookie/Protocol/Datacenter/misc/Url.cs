

// Generated on 12/06/2016 11:35:51
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("Url")]
    public class Url : IDataObject
    {
        public const String MODULE = "Url";
        public int Id;
        public int BrowserId;
        public String url;
        public String Param;
        public String Method;
    }
}