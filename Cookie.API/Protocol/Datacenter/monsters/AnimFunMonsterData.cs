using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("AnimFunMonsterData")]
    public class AnimFunMonsterData : IDataObject
    {
		private const string MODULE = "AnimFunMonsterData";
		public string AnimName;
		public int AnimWeight;
    }
}
