using Cookie.API.Gamedata.D2o;
using System.Collections.Generic;
using Cookie.API.Gamedata.D2o.other;

namespace Cookie.API.Datacenter
{
    [D2oClass("Monster")]
    public class Monster : IDataObject
    {
		private const string MODULE = "Monster";
		public int Id;
		public int NameId;
		public int GfxId;
		public int Race;
		public List<MonsterGrade> Grades;
		public string Look;
		public bool UseSummonSlot;
		public bool UseBombSlot;
		public List<AnimFunMonsterData> AnimFunList;
		public bool IsBoss;
		public List<MonsterDrop> Drops;
		public List<MonsterDrop> TemporisDrops;
		public List<uint> Subareas;
		public List<uint> Spells;
		public int FavoriteSubareaId;
		public bool IsMiniBoss;
		public bool IsQuestMonster;
		public int CorrespondingMiniBossId;
		public int SpeedAdjust;
		public int CreatureBoneId;
		public bool FastAnimsFun;
		public bool CanPlay;
		public bool CanTackle;
		public bool CanBePushed;
		public bool CanSwitchPos;
		public bool CanBeCarried;
		public bool CanUsePortal;
		public List<uint> IncompatibleIdols;
		public bool AllIdolsDisabled;
		public bool DareAvailable;
		public List<uint> IncompatibleChallenges;
		public bool UseRaceValues;
		public int AggressiveZoneSize;
		public int AggressiveLevelDiff;
		public string AggressiveImmunityCriterion;
		public int AggressiveAttackDelay;
    }
}
