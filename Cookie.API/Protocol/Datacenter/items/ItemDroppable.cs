using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("ItemDroppable")]
    public class ItemDroppable : IDataObject
    {
		private const string MODULE = "ItemDroppable";
		public int Id;
    }
}
