using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("Mount")]
    public class Mount : IDataObject
    {
		private const string MODULE = "Mount";
		public int Id;
		public int FamilyId;
		public int NameId;
		public string Look;
		public int CertificateId;
		public List<EffectInstance> Effects;
    }
}
