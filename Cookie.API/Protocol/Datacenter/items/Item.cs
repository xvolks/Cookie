// Generated on 12/06/2016 11:35:50

using System.Collections.Generic;
using Cookie.API.Gamedata.D2o;

namespace Cookie.API.Datacenter
{
    [D2oClass("Items")]
    public class Item : IDataObject
    {
        public const string MODULE = "Items";
        public const uint EQUIPEMENTCATEGORY = 0;
        public const uint CONSUMABLESCATEGORY = 1;
        public const uint RESSOURCESCATEGORY = 2;
        public const uint QUESTCATEGORY = 3;
        public const uint OTHERCATEGORY = 4;
        public const int MAXJOBLEVELGAP = 100;
        public uint AppearanceId;
        public bool BonusIsSecret;
        public List<uint> ContainerIds;
        public int CraftXpRatio;
        public string Criteria;
        public string CriteriaTarget;
        public bool Cursed;
        public uint DescriptionId;
        public List<uint> DropMonsterIds;
        public bool Enhanceable;
        public bool Etheral;
        public bool Exchangeable;
        public List<uint> FavoriteSubAreas;
        public uint FavoriteSubAreasBonus;
        public bool HideEffects;
        public int IconId;
        public int Id;
        public bool IsDestructible;
        public int ItemSetId;
        public uint Level;
        public uint NameId;
        public bool NeedUseConfirm;
        public bool NonUsableOnAnother;
        public List<List<float>> NuggetsBySubarea;
        public List<EffectInstance> PossibleEffects;
        public float Price;
        public uint RealWeight;
        public List<uint> RecipeIds;
        public uint RecipeSlots;
        public List<List<int>> ResourcesBySubarea;
        public bool SecretRecipe;
        public bool Targetable;
        public bool TwoHanded;
        public ItemType Type;
        public uint TypeId;
        public bool Usable;
        public int UseAnimationId;
        public uint Weight;
    }
}