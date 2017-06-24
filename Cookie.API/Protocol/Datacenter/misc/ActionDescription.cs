// Generated on 12/06/2016 11:35:51

using Cookie.API.Gamedata.D2o;

namespace Cookie.API.Datacenter
{
    [D2oClass("ActionDescriptions")]
    public class ActionDescription : IDataObject
    {
        public const string MODULE = "ActionDescriptions";
        public uint DescriptionId;
        public uint Id;
        public uint MaxUsePerFrame;
        public uint MinimalUseInterval;
        public string Name;
        public bool NeedConfirmation;
        public bool NeedInteraction;
        public bool Trusted;
        public uint TypeId;
    }
}