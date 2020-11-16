using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("ExternalNotification")]
    public class ExternalNotification : IDataObject
    {
		private const string MODULE = "ExternalNotification";
		public int Id;
		public int CategoryId;
		public int IconId;
		public int ColorId;
		public int DescriptionId;
		public bool DefaultEnable;
		public bool DefaultSound;
		public bool DefaultMultiAccount;
		public bool DefaultNotify;
		public string Name;
		public int MessageId;
    }
}
