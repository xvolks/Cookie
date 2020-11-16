using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("SoundUiHook")]
    public class SoundUiHook : IDataObject
    {
		private const string MODULE = "SoundUiHook";
		public int Id;
		public string Name;
    }
}
