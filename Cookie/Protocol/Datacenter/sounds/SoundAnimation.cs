

// Generated on 12/06/2016 11:35:52
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("SoundAnimations")]
    public class SoundAnimation : IDataObject
    {
        public String MODULE = "SoundAnimations";
        public uint Id;
        public String Name;
        public String Label;
        public String Filename;
        public int Volume;
        public int Rolloff;
        public int AutomationDuration;
        public int AutomationVolume;
        public int AutomationFadeIn;
        public int AutomationFadeOut;
        public Boolean NoCutSilence;
        public uint StartFrame;
    }
}