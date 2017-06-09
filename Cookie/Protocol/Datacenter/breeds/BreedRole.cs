

// Generated on 12/06/2016 11:35:50
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("BreedRoles")]
    public class BreedRole : IDataObject
    {
        public const String MODULE = "BreedRoles";
        public int Id;
        public uint NameId;
        public uint DescriptionId;
        public int AssetId;
        public int Color;
    }
}