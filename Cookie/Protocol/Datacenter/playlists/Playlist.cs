

// Generated on 12/06/2016 11:35:51
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("Playlists")]
    public class Playlist : IDataObject
    {
        public const int AMBIENTTYPEROLEPLAY = 1;
        public const int AMBIENTTYPEAMBIENT = 2;
        public const int AMBIENTTYPEFIGHT = 3;
        public const int AMBIENTTYPEBOSS = 4;
        public const String MODULE = "Playlists";
        public int Id;
        public int SilenceDuration;
        public int Iteration;
        public int Type;
        public List<PlaylistSound> Sounds;
    }
}