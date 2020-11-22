using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("Playlist")]
    public class Playlist : IDataObject
    {
		private const string MODULE = "Playlist";
		public int Id;
		public uint SilenceDuration;
		public int Iteration;
		public int Type;
		public List<PlaylistSound> Sounds;
    }
}
