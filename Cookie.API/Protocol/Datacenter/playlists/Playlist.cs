// Generated on 12/06/2016 11:35:51

using System.Collections.Generic;
using Cookie.API.Gamedata.D2o;

namespace Cookie.API.Datacenter
{
    [D2oClass("Playlists")]
    public class Playlist : IDataObject
    {
        public const int AMBIENTTYPEROLEPLAY = 1;
        public const int AMBIENTTYPEAMBIENT = 2;
        public const int AMBIENTTYPEFIGHT = 3;
        public const int AMBIENTTYPEBOSS = 4;
        public const string MODULE = "Playlists";
        public int Id;
        public int Iteration;
        public int SilenceDuration;
        public List<PlaylistSound> Sounds;
        public int Type;
    }
}