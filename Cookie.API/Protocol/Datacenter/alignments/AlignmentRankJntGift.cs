using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("AlignmentRankJntGift")]
    public class AlignmentRankJntGift : IDataObject
    {
		private const string MODULE = "AlignmentRankJntGift";
		public int Id;
		public List<int> Gifts;
		public List<int> Parameters;
		public List<int> Levels;
    }
}
