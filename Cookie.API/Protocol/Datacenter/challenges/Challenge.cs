using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("Challenge")]
    public class Challenge : IDataObject
    {
		private const string MODULE = "Challenge";
		public int Id;
		public int NameId;
		public int DescriptionId;
		public bool DareAvailable;
		public List<uint> IncompatibleChallenges;
    }
}
