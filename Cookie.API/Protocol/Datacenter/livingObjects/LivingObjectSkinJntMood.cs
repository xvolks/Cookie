using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("LivingObjectSkinJntMood")]
    public class LivingObjectSkinJntMood : IDataObject
    {
		private const string MODULE = "LivingObjectSkinJntMood";
		public int SkinId;
		public List<List<int>> Moods;
    }
}
