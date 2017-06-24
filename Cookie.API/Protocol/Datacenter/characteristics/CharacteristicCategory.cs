// Generated on 12/06/2016 11:35:50

using System.Collections.Generic;
using Cookie.API.Gamedata.D2o;

namespace Cookie.API.Datacenter
{
    [D2oClass("CharacteristicCategories")]
    public class CharacteristicCategory : IDataObject
    {
        public const string MODULE = "CharacteristicCategories";
        public List<uint> CharacteristicIds;
        public int Id;
        public uint NameId;
        public int Order;
    }
}