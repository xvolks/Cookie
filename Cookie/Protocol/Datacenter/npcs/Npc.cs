

// Generated on 12/06/2016 11:35:51
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("Npcs")]
    public class Npc : IDataObject
    {
        public const String MODULE = "Npcs";
        public int Id;
        public uint NameId;
        public List<List<int>> DialogMessages;
        public List<List<int>> DialogReplies;
        public List<uint> Actions;
        public uint Gender;
        public String Look;
        public int TokenShop;
        public List<AnimFunNpcData> AnimFunList;
        public Boolean FastAnimsFun;
    }
}