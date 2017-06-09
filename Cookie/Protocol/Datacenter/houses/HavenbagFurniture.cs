

// Generated on 12/06/2016 11:35:50
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("HavenbagFurnitures")]
    public class HavenbagFurniture : IDataObject
    {
        public const String MODULE = "HavenbagFurnitures";
        public int TypeId;
        public int ThemeId;
        public int ElementId;
        public int Color;
        public int SkillId;
        public int LayerId;
        public Boolean BlocksMovement;
        public Boolean IsStackable;
        public uint CellsWidth;
        public uint CellsHeight;
        public uint Order;
    }
}