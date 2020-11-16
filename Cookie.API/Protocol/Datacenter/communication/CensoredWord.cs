using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("CensoredWord")]
    public class CensoredWord : IDataObject
    {
		private const string MODULE = "CensoredWord";
		public int Id;
		public int ListId;
		public string Language;
		public string Word;
		public bool DeepLooking;
    }
}
