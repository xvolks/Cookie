// Generated on 12/06/2016 11:35:49

using Cookie.API.Gamedata.D2o;

namespace Cookie.API.Datacenter
{
    [D2oClass("AmbientSounds")]
    public class AmbientSound : PlaylistSound
    {
        public const int AMBIENTTYPEROLEPLAY = 1;
        public const int AMBIENTTYPEAMBIENT = 2;
        public const int AMBIENTTYPEFIGHT = 3;
        public const int AMBIENTTYPEBOSS = 4;
        public new const string MODULE = "AmbientSounds";
        public int CriterionId;
        public uint SilenceMax;
        public uint SilenceMin;
        public int Typeid;
    }
}