

// Generated on 12/06/2016 11:35:51
using System;
using System.Collections.Generic;
using Cookie.Gamedata.D2o;

namespace Cookie.Datacenter
{
    [D2oClass("Monsters")]
    public class Monster : IDataObject
    {
        public const String MODULE = "Monsters";
        public int Id;
        public uint NameId;
        public uint GfxId;
        public int Race;
        public List<MonsterGrade> Grades;
        public String Look;
        public Boolean UseSummonSlot;
        public Boolean UseBombSlot;
        public Boolean CanPlay;
        public Boolean CanTackle;
        public List<AnimFunMonsterData> AnimFunList;
        public Boolean IsBoss;
        public List<MonsterDrop> Drops;
        public List<uint> Subareas;
        public List<uint> Spells;
        public int FavoriteSubareaId;
        public Boolean IsMiniBoss;
        public Boolean IsQuestMonster;
        public uint CorrespondingMiniBossId;
        public float SpeedAdjust = 0;
        public int CreatureBoneId;
        public Boolean CanBePushed;
        public Boolean FastAnimsFun;
        public Boolean CanSwitchPos;
        public List<uint> IncompatibleIdols;
        public Boolean AllIdolsDisabled;
        public Boolean DareAvailable;
        public List<uint> IncompatibleChallenges;
        public List<int> TemporisDrops;
        public Boolean CanBeCarried;
        public Boolean CanUsePortal;
        public Boolean UseRaceValues;
        public int AggressiveZoneSize;
        public int AggressiveLevelDiff;
        public String AggressiveImmunityCriterion;
        public int AggressiveAttackDelay;
    }
}