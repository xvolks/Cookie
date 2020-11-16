using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("MapPosition")]
    public class MapPosition : IDataObject
    {
		private const string MODULE = "MapPosition";
		public int Id;
		public int PosX;
		public int PosY;
		public bool Outdoor;
		public int Capabilities;
		public int NameId;
		public List<AmbientSound> Sounds;
		public int SubAreaId;
		public int WorldMap;
		public bool HasPriorityOnWorldmap;
		public bool ShowNameOnFingerpost;
		public List<List<int>> Playlists;
		public bool AllowPrism;
		public bool IsTransition;
		public uint TacticalModeTemplateId;
		public bool HasPublicPaddock;
    }
}
