using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("Notification")]
    public class Notification : IDataObject
    {
		private const string MODULE = "Notification";
		public int Id;
		public int TitleId;
		public int MessageId;
		public int IconId;
		public int TypeId;
		public string Trigger;
    }
}
