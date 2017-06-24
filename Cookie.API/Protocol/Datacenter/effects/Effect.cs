// Generated on 12/06/2016 11:35:50

using Cookie.API.Gamedata.D2o;

namespace Cookie.API.Datacenter
{
    [D2oClass("Effects")]
    public class Effect : IDataObject
    {
        public const string MODULE = "Effects";
        public bool Active;
        public int BonusType;
        public bool Boost;
        public uint Category;
        public int Characteristic;
        public uint DescriptionId;
        public uint EffectPriority;
        public int ElementId;
        public bool ForceMinMax;
        public int IconId;
        public int Id;
        public string Operator;
        public int OppositeId;
        public bool ShowInSet;
        public bool ShowInTooltip;
        public uint TheoreticalDescriptionId;
        public uint TheoreticalPattern;
        public bool UseDice;
        public bool UseInFight;
    }
}