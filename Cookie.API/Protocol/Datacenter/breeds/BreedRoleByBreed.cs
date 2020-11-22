using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("BreedRoleByBreed")]
    public class BreedRoleByBreed : IDataObject
    {
		private const string MODULE = "BreedRoleByBreed";
		public int BreedId;
		public int RoleId;
		public int DescriptionId;
		public int Value;
		public int Order;
    }
}
