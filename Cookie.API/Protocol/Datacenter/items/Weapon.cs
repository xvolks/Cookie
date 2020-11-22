using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("Weapon")]
    public class Weapon : IDataObject
    {
		private const string MODULE = "Weapon";
		public bool Etheral;
		public bool Cursed;
		public int AppearanceId;
		public string Criteria;
		public int CriticalFailureProbability;
		public string CraftVisible;
		public bool NonUsableOnAnother;
		public bool Enhanceable;
		public List<EffectInstance> PossibleEffects;
		public int CriticalHitBonus;
		public List<uint> RecipeIds;
		public double Price;
		public List<List<double>> NuggetsBySubarea;
		public int Id;
		public List<uint> DropTemporisMonsterIds;
		public int IconId;
		public int Level;
		public bool NeedUseConfirm;
		public int FavoriteSubAreasBonus;
		public int CraftXpRatio;
		public int UseAnimationId;
		public int NameId;
		public int TypeId;
		public int RecipeSlots;
		public int MinRange;
		public bool Exchangeable;
		public int CriticalHitProbability;
		public bool IsSaleable;
		public int Range;
		public bool CastInLine;
		public int ApCost;
		public bool CastInDiagonal;
		public bool Usable;
		public List<uint> ContainerIds;
		public bool ObjectIsDisplayOnWeb;
		public int DescriptionId;
		public bool TwoHanded;
		public List<uint> EvolutiveEffectIds;
		public string CriteriaTarget;
		public List<uint> FavoriteSubAreas;
		public bool SecretRecipe;
		public bool HideEffects;
		public string CraftFeasible;
		public bool CastTestLos;
		public List<List<int>> ResourcesBySubarea;
		public int RealWeight;
		public bool Targetable;
		public bool IsDestructible;
		public int ItemSetId;
		public List<uint> DropMonsterIds;
		public bool BonusIsSecret;
		public int MaxCastPerTurn;
		public string Visibility;

	}
}
