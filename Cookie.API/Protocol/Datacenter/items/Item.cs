using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("Item")]
    public class Item : IDataObject
    {
		private const string MODULE = "Item";
		public int Id;
		public int NameId;
		public int TypeId;
		public int DescriptionId;
		public int IconId;
		public int Level;
		public int RealWeight;
		public bool Cursed;
		public int UseAnimationId;
		public bool Usable;
		public bool Targetable;
		public bool Exchangeable;
		public double Price;
		public bool TwoHanded;
		public bool Etheral;
		public int ItemSetId;
		public string Criteria;
		public string CriteriaTarget;
		public bool HideEffects;
		public bool Enhanceable;
		public bool NonUsableOnAnother;
		public int AppearanceId;
		public bool SecretRecipe;
		public int RecipeSlots;
		public List<uint> RecipeIds;
		public List<uint> DropMonsterIds;
		public List<uint> DropTemporisMonsterIds;
		public bool ObjectIsDisplayOnWeb;
		public bool BonusIsSecret;
		public List<EffectInstance> PossibleEffects;
		public List<uint> EvolutiveEffectIds;
		public List<uint> FavoriteSubAreas;
		public int FavoriteSubAreasBonus;
		public int CraftXpRatio;
		public bool NeedUseConfirm;
		public bool IsDestructible;
		public bool IsSaleable;
		public string CraftVisible;
		public string CraftFeasible;
		public List<List<double>> NuggetsBySubarea;
		public List<uint> ContainerIds;
		public List<List<int>> ResourcesBySubarea;
		public string Visibility;

	}
}
