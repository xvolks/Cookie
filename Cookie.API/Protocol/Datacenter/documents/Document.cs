// Generated on 12/06/2016 11:35:50

using Cookie.API.Gamedata.D2o;

namespace Cookie.API.Datacenter
{
    [D2oClass("Documents")]
    public class Document : IDataObject
    {
        private const string MODULE = "Documents";
        public uint AuthorId;
        public string ClientProperties;
        public string ContentCSS;
        public uint ContentId;
        public int Id;
        public bool ShowBackgroundImage;
        public bool ShowTitle;
        public uint SubTitleId;
        public uint TitleId;
        public uint TypeId;
    }
}