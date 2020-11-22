using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("AmbientSound")]
    public class AmbientSound : IDataObject
    {
		private const string MODULE = "AmbientSound";
		public string Id;
		public int Volume;
		public int CriterionId;
		public int SilenceMin;
		public int SilenceMax;
		public int Channel;
		public int Typeid;
    }
}
