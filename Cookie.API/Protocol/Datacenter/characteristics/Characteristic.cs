// Generated on 12/06/2016 11:35:50

using Cookie.API.Gamedata.D2o;

namespace Cookie.API.Datacenter
{
    [D2oClass("Characteristics")]
    public class Characteristic : IDataObject
    {
        public const string MODULE = "Characteristics";
        public string Asset;
        public int CategoryId;
        public int Id;
        public string Keyword;
        public uint NameId;
        public int Order;
        public bool Upgradable;
        public bool Visible;
    }
}