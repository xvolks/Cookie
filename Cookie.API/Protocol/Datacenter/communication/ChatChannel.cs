using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("ChatChannel")]
    public class ChatChannel : IDataObject
    {
		private const string MODULE = "ChatChannel";
		public int Id;
		public int NameId;
		public int DescriptionId;
		public string Shortcut;
		public string ShortcutKey;
		public bool IsPrivate;
		public bool AllowObjects;
    }
}
