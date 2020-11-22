using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("Effect")]
    public class Effect : IDataObject
    {
		private const string MODULE = "Effect";
		public int Id;
		public int DescriptionId;
		public int IconId;
		public int Characteristic;
		public int Category;
		public string Operator;
		public bool ShowInTooltip;
		public bool UseDice;
		public bool ForceMinMax;
		public bool Boost;
		public bool Active;
		public int OppositeId;
		public int TheoreticalDescriptionId;
		public int TheoreticalPattern;
		public bool ShowInSet;
		public int BonusType;
		public bool UseInFight;
		public int EffectPriority;
		public int ElementId;
    }
}
