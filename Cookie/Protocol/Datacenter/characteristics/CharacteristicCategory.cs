

// Generated on 12/06/2016 11:35:50
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("CharacteristicCategories")]
    public class CharacteristicCategory : IDataObject
    {
        public const String MODULE = "CharacteristicCategories";
        public int Id;
        public uint NameId;
        public int Order;
        public List<uint> CharacteristicIds;
    }
}