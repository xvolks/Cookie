// Generated on 12/06/2016 11:35:51

using System.Collections.Generic;
using Cookie.API.Gamedata.D2o;

namespace Cookie.API.Datacenter
{
    [D2oClass("Skills")]
    public class Skill : IDataObject
    {
        public const string MODULE = "Skills";
        public bool AvailableInHouse;
        public bool ClientDisplay;
        public List<int> CraftableItemIds;
        public int Cursor;
        public int ElementActionId;
        public int GatheredRessourceItem;
        public int Id;
        public int InteractiveId;
        public bool IsForgemagus;
        public uint LevelMin;
        public List<int> ModifiableItemTypeIds;
        public uint NameId;
        public int ParentJobId;
        public string UseAnimation;
    }
}