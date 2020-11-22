using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("InfoMessage")]
    public class InfoMessage : IDataObject
    {
		private const string MODULE = "InfoMessage";
		public uint TypeId;
		public uint MessageId;
		public int TextId;
    }
}
