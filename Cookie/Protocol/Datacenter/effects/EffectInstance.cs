

// Generated on 12/06/2016 11:35:50
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("EffectInstance")]
    public class EffectInstance : IDataObject
    {
        public uint EffectUid;
        public uint EffectId;
        public int TargetId;
        public String TargetMask;
        public int Duration;
        public int Delay;
        public int Random;
        public int Group;
        public int Modificator;
        public Boolean Trigger;
        public String Triggers;
        public Boolean VisibleInTooltip = true;
        public Boolean VisibleInBuffUi = true;
        public Boolean VisibleInFightLog = true;
        public Object ZoneSize;
        public uint ZoneShape;
        public Object ZoneMinSize;
        public Object ZoneEfficiencyPercent;
        public Object ZoneMaxEfficiency;
        public Object ZoneStopAtTarget;
        public int EffectElement;
        public Boolean RawZoneInit;
        public String RawZone;
    }
}