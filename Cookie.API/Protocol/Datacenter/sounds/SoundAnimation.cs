using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("SoundAnimation")]
    public class SoundAnimation : IDataObject
    {
		private const string MODULE = "SoundAnimation";
		public int Id;
		public string Label;
		public string Name;
		public string Filename;
		public int Volume;
		public int Rolloff;
		public int AutomationDuration;
		public int AutomationVolume;
		public int AutomationFadeIn;
		public int AutomationFadeOut;
		public bool NoCutSilence;
		public int StartFrame;
    }
}
