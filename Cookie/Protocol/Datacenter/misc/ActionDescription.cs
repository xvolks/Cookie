

// Generated on 12/06/2016 11:35:51
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("ActionDescriptions")]
    public class ActionDescription : IDataObject
    {
        public const String MODULE = "ActionDescriptions";
        public uint Id;
        public uint TypeId;
        public String Name;
        public uint DescriptionId;
        public Boolean Trusted;
        public Boolean NeedInteraction;
        public uint MaxUsePerFrame;
        public uint MinimalUseInterval;
        public Boolean NeedConfirmation;
    }
}