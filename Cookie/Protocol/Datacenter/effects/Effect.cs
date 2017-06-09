

// Generated on 12/06/2016 11:35:50
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("Effects")]
    public class Effect : IDataObject
    {
        public const String MODULE = "Effects";
        public int Id;
        public uint DescriptionId;
        public int IconId;
        public int Characteristic;
        public uint Category;
        public String Operator;
        public Boolean ShowInTooltip;
        public Boolean UseDice;
        public Boolean ForceMinMax;
        public Boolean Boost;
        public Boolean Active;
        public int OppositeId;
        public uint TheoreticalDescriptionId;
        public uint TheoreticalPattern;
        public Boolean ShowInSet;
        public int BonusType;
        public Boolean UseInFight;
        public uint EffectPriority;
        public int ElementId;
    }
}