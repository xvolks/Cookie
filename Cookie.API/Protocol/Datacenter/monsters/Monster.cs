// Generated on 12/06/2016 11:35:51

using System.Collections.Generic;
using Cookie.API.Gamedata.D2o;

namespace Cookie.API.Datacenter
{
    [D2oClass("Monsters")]
    public class Monster : IDataObject
    {
        public const string MODULE = "Monsters";
        public bool AllIdolsDisabled;
        public List<AnimFunMonsterData> AnimFunList;
        public bool CanBePushed;
        public bool CanPlay;
        public bool CanSwitchPos;
        public bool CanTackle;
        public uint CorrespondingMiniBossId;
        public int CreatureBoneId;
        public bool DareAvailable;
        public List<MonsterDrop> Drops;
        public bool FastAnimsFun;
        public int FavoriteSubareaId;
        public uint GfxId;
        public List<MonsterGrade> Grades;
        public int Id;
        public List<uint> IncompatibleChallenges;
        public List<uint> IncompatibleIdols;
        public bool IsBoss;
        public bool IsMiniBoss;
        public bool IsQuestMonster;
        public string Look;
        public uint NameId;
        public int Race;
        public float SpeedAdjust = 0;
        public List<uint> Spells;
        public List<uint> Subareas;
        public bool UseBombSlot;
        public bool UseSummonSlot;
    }
}