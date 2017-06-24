// Generated on 12/06/2016 11:35:50

using Cookie.API.Gamedata.D2o;

namespace Cookie.API.Datacenter
{
    [D2oClass("EffectInstance")]
    public class EffectInstance : IDataObject
    {
        public int Delay;
        public int Duration;
        public int EffectElement;
        public uint EffectId;
        public uint EffectUid;
        public int Group;
        public int Modificator;
        public int Random;
        public string RawZone;
        public bool RawZoneInit;
        public int TargetId;
        public string TargetMask;
        public bool Trigger;
        public string Triggers;
        public bool VisibleInBuffUi = true;
        public bool VisibleInFightLog = true;
        public bool VisibleInTooltip = true;
        public object ZoneEfficiencyPercent;
        public object ZoneMaxEfficiency;
        public object ZoneMinSize;
        public uint ZoneShape;
        public object ZoneSize;
        public object ZoneStopAtTarget;
    }
}