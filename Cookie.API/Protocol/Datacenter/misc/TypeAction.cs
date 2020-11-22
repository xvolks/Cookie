using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("TypeAction")]
    public class TypeAction : IDataObject
    {
		private const string MODULE = "TypeAction";
		public int Id;
		public string ElementName;
		public int ElementId;
    }
}
