using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("SoundBones")]
    public class SoundBones : IDataObject
    {
		private const string MODULE = "SoundBones";
		public int Id;
		public List<string> Keys;
		public List<List<SoundAnimation>> Values;
    }
}
