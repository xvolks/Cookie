// Generated on 12/06/2016 11:35:51

using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("CompanionCharacteristics")]
    public class CompanionCharacteristic : IDataObject
    {
        public const string MODULE = "CompanionCharacteristics";
        public int CaracId;
        public int CompanionId;
        public int Id;
        public int Order;
        public List<List<float>> StatPerLevelRange;
    }
}