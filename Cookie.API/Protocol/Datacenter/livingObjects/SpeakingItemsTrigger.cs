using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("SpeakingItemsTrigger")]
    public class SpeakingItemsTrigger : IDataObject
    {
		private const string MODULE = "SpeakingItemsTrigger";
		public int TriggersId;
		public List<int> TextIds;
		public List<int> States;
    }
}
