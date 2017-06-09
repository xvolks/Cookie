

// Generated on 12/06/2016 11:35:50
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("BreedRoleByBreeds")]
    public class BreedRoleByBreed : IDataObject
    {
        public const String MODULE = "BreedRoleByBreeds";
        public int BreedId;
        public int RoleId;
        public uint DescriptionId;
        public int Value;
        public int Order;
    }
}