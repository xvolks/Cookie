using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("SpeakingItemText")]
    public class SpeakingItemText : IDataObject
    {
		private const string MODULE = "SpeakingItemText";
		public int TextId;
		public double TextProba;
		public int TextStringId;
		public int TextLevel;
		public int TextSound;
		public string TextRestriction;
    }
}
