// Generated on 12/06/2016 11:35:51

using System.Collections.Generic;
using Cookie.API.Gamedata.D2o;

namespace Cookie.API.Datacenter
{
    [D2oClass("Recipes")]
    public class Recipe : IDataObject
    {
        public const string MODULE = "Recipes";
        public List<int> IngredientIds;
        public int JobId;
        public List<uint> Quantities;
        public int ResultId;
        public uint ResultLevel;
        public uint ResultNameId;
        public uint ResultTypeId;
        public int SkillId;
    }
}