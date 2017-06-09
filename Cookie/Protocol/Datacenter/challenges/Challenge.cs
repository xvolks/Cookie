

// Generated on 12/06/2016 11:35:50
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("Challenge")]
    public class Challenge : IDataObject
    {
        public const String MODULE = "Challenge";
        public int Id;
        public uint NameId;
        public uint DescriptionId;
        public Boolean DareAvailable;
        public List<uint> IncompatibleChallenges;
    }
}