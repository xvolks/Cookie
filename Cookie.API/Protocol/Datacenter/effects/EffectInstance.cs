using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("EffectInstance")]
    public class EffectInstance : IDataObject
    {
		private const string MODULE = "EffectInstance";
		public int EffectUid;
		public int EffectId;
		public int Order;
		public int TargetId;
		public string TargetMask;
		public int Duration;
		public int Random;
		public int Group;
		public bool VisibleInTooltip;
		public bool VisibleInBuffUi;
		public bool VisibleInFightLog;
		public bool ForClientOnly;
		public int Dispellable;
		public string RawZone;
		public int Delay;
		public string Triggers;
		public int EffectElement;
		public int SpellId;
		public bool VisibleOnTerrain;

	}
}
