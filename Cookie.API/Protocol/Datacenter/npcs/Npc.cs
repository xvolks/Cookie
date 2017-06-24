// Generated on 12/06/2016 11:35:51

using System.Collections.Generic;
using Cookie.API.Gamedata.D2o;

namespace Cookie.API.Datacenter
{
    [D2oClass("Npcs")]
    public class Npc : IDataObject
    {
        public const string MODULE = "Npcs";
        public List<uint> Actions;
        public List<AnimFunNpcData> AnimFunList;
        public List<List<int>> DialogMessages;
        public List<List<int>> DialogReplies;
        public bool FastAnimsFun;
        public uint Gender;
        public int Id;
        public string Look;
        public uint NameId;
        public int TokenShop;
    }
}