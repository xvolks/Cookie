

// Generated on 12/06/2016 11:35:52
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("FinishMoves")]
    public class FinishMove : IDataObject
    {
        public const String MODULE = "FinishMoves";
        public int Id;
        public int Duration;
        public Boolean Free;
        public uint NameId;
        public int Category;
        public int SpellLevel;
    }
}