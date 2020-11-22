using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("MonsterDrop")]
    public class MonsterDrop : IDataObject
    {
		private const string MODULE = "MonsterDrop";
		public int DropId;
		public int MonsterId;
		public int ObjectId;
		public double PercentDropForGrade1;
		public double PercentDropForGrade2;
		public double PercentDropForGrade3;
		public double PercentDropForGrade4;
		public double PercentDropForGrade5;
		public int Count;
		public string Criteria;
		public bool HasCriteria;
		public List<MonsterDropCoefficient> SpecificDropCoefficient;
    }
}
