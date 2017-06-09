

// Generated on 12/06/2016 11:35:49
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("Ornaments")]
    public class Ornament : IDataObject
    {
        public const String MODULE = "Ornaments";
        public int Id;
        public uint NameId;
        public Boolean Visible;
        public int AssetId;
        public int IconId;
        public int Rarity;
        public int Order;
    }
}