using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("AnimFunNpcData")]
    public class AnimFunNpcData : IDataObject
    {
		private const string MODULE = "AnimFunNpcData";
		public string AnimName;
		public int AnimWeight;
    }
}
