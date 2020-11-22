using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("SoundUiElement")]
    public class SoundUiElement : IDataObject
    {
		private const string MODULE = "SoundUiElement";
		public int Id;
		public string Name;
		public int HookId;
		public string File;
    }
}
