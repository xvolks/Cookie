using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("SkinPosition")]
    public class SkinPosition : IDataObject
    {
		private const string MODULE = "SkinPosition";
		public int Id;
		public List<TransformData> Transformation;
		public List<string> Clip;
		public List<uint> Skin;
    }
}
