using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("MonsterDropCoefficient")]
    public class MonsterDropCoefficient : IDataObject
    {
		private const string MODULE = "MonsterDropCoefficient";
		public int MonsterId;
		public int MonsterGrade;
		public double DropCoefficient;
		public string Criteria;
    }
}
