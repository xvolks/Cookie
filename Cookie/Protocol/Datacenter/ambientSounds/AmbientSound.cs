

// Generated on 12/06/2016 11:35:49
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("AmbientSounds")]
    public class AmbientSound : PlaylistSound
    {
        public const int AMBIENTTYPEROLEPLAY = 1;
        public const int AMBIENTTYPEAMBIENT = 2;
        public const int AMBIENTTYPEFIGHT = 3;
        public const int AMBIENTTYPEBOSS = 4;
        public new const String MODULE = "AmbientSounds";
        public int CriterionId;
        public uint SilenceMin;
        public uint SilenceMax;
        public int Typeid;
    }
}