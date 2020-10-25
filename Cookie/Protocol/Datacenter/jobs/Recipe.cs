

// Generated on 12/06/2016 11:35:51
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("Recipes")]
    public class Recipe : IDataObject
    {
        public const String MODULE = "Recipes";
        public int ResultId;
        public uint ResultNameId;
        public uint ResultTypeId;
        public uint ResultLevel;
        public List<int> IngredientIds;
        public List<uint> Quantities;
        public int JobId;
        public int SkillId;
        public int Order;
    }
}