using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("Npc")]
    public class Npc : IDataObject
    {
		private const string MODULE = "Npc";
		public int Id;
		public int NameId;
		public List<List<int>> DialogMessages;
		public List<List<int>> DialogReplies;
		public List<uint> Actions;
		public int Gender;
		public string Look;
		public List<AnimFunNpcData> AnimFunList;
		public bool FastAnimsFun;
    }
}
