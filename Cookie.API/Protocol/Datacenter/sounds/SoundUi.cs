using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("SoundUi")]
    public class SoundUi : IDataObject
    {
		private const string MODULE = "SoundUi";
		public int Id;
		public string UiName;
		public string OpenFile;
		public string CloseFile;
		public List<List<SoundUi>> SubElements;
    }
}
