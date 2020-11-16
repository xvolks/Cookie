// Generated on 12/06/2016 11:35:49
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("BreachPrizes")]
    public class BreachPrize : IDataObject
    {
        public const String MODULE = "BreachPrizes";
        public int Id;
        public uint NameId;
        public uint CategoryId;
        public int currency;
        public string TooltipKey;
        public int DescriptionKey;
        public int ItemId;
    }
}