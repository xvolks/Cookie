using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("Title")]
    public class Title : IDataObject
    {
		private const string MODULE = "Title";
		public int Id;
		public int NameMaleId;
		public int NameFemaleId;
		public bool Visible;
		public int CategoryId;
    }
}
