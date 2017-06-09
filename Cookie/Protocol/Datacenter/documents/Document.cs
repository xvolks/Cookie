

// Generated on 12/06/2016 11:35:50
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("Documents")]
    public class Document : IDataObject
    {
        private const String MODULE = "Documents";
        public int Id;
        public uint TypeId;
        public Boolean ShowTitle;
        public Boolean ShowBackgroundImage;
        public uint TitleId;
        public uint AuthorId;
        public uint SubTitleId;
        public uint ContentId;
        public String ContentCSS;
        public String ClientProperties;
    }
}