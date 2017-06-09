

// Generated on 12/06/2016 11:35:50
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("Items")]
    public class Item : IDataObject
    {
        public const String MODULE = "Items";
        public const uint EQUIPEMENTCATEGORY = 0;
        public const uint CONSUMABLESCATEGORY = 1;
        public const uint RESSOURCESCATEGORY = 2;
        public const uint QUESTCATEGORY = 3;
        public const uint OTHERCATEGORY = 4;
        public const int MAXJOBLEVELGAP = 100;
        public int Id;
        public uint NameId;
        public uint TypeId;
        public uint DescriptionId;
        public int IconId;
        public uint Level;
        public uint RealWeight;
        public Boolean Cursed;
        public int UseAnimationId;
        public Boolean Usable;
        public Boolean Targetable;
        public Boolean Exchangeable;
        public float Price;
        public Boolean TwoHanded;
        public Boolean Etheral;
        public int ItemSetId;
        public String Criteria;
        public String CriteriaTarget;
        public Boolean HideEffects;
        public Boolean Enhanceable;
        public Boolean NonUsableOnAnother;
        public uint AppearanceId;
        public Boolean SecretRecipe;
        public List<uint> DropMonsterIds;
        public uint RecipeSlots;
        public List<uint> RecipeIds;
        public Boolean BonusIsSecret;
        public List<EffectInstance> PossibleEffects;
        public List<uint> FavoriteSubAreas;
        public uint FavoriteSubAreasBonus;
        public int CraftXpRatio;
        public Boolean NeedUseConfirm;
        public Boolean IsDestructible;
        public List<List<float>> NuggetsBySubarea;
        public List<uint> ContainerIds;
        public List<List<int>> ResourcesBySubarea;
        public ItemType Type;
        public uint Weight;
    }
}