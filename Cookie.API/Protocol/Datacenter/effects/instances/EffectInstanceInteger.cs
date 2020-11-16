using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("EffectInstanceInteger")]
    public class EffectInstanceInteger : IDataObject
    {
		private const string MODULE = "EffectInstanceInteger";
		public string TargetMask;
		public bool VisibleInBuffUi;
		public bool VisibleInFightLog;
		public int TargetId;
		public int EffectElement;
		public int EffectUid;
		public int Dispellable;
		public string Triggers;
		public int SpellId;
		public int Duration;
		public int Random;
		public int EffectId;
		public int Delay;
		public bool VisibleInTooltip;
		public string RawZone;
		public bool ForClientOnly;
		public int Value;
		public int Order;
		public int Group;
		public bool VisibleOnTerrain;

	}
}
