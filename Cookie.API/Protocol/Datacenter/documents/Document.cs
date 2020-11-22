using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("Document")]
    public class Document : IDataObject
    {
		private const string MODULE = "Document";
		public int Id;
		public int TypeId;
		public bool ShowTitle;
		public bool ShowBackgroundImage;
		public int TitleId;
		public int AuthorId;
		public int SubTitleId;
		public int ContentId;
		public string ContentCSS;
		public string ClientProperties;
    }
}
