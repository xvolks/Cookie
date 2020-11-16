using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("AlignmentGift")]
    public class AlignmentGift : IDataObject
    {
		private const string MODULE = "AlignmentGift";
		public int Id;
		public int NameId;
		public int EffectId;
		public int GfxId;
    }
}
