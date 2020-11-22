using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("PlaylistSound")]
    public class PlaylistSound : IDataObject
    {
		private const string MODULE = "PlaylistSound";
		public string Id;
		public int Volume;
    }
}
