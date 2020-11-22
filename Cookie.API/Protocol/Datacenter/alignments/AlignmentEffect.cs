using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("AlignmentEffect")]
    public class AlignmentEffect : IDataObject
    {
		private const string MODULE = "AlignmentEffect";
		public int Id;
		public int CharacteristicId;
		public int DescriptionId;
    }
}
