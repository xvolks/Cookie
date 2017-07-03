using Cookie.API.Game.Entity;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay;
using Cookie.API.Gamedata.D2o;
using Cookie.API.Datacenter;
using Cookie.API.Gamedata.D2i;

namespace Cookie.Game.Entity
{
    public class MonsterGroup : IMonsterGroup
    {
        public GroupMonsterStaticInformations StaticInfos { get; set; }

        public int MonstersCount => StaticInfos.Underlings.Count + 1;

        public int GroupLevel
        {
            get
            {
                var groupLevel = 0;
                foreach (var monster in StaticInfos.Underlings)
                {
                    var monsterGrade = ObjectDataManager.Instance.Get<Monster>(monster.CreatureGenericId).Grades;
                    var monsterGradeData = monsterGrade[monster.Grade - 1];
                    groupLevel += (int)monsterGradeData.Level;
                }
                var mainMonsterGrade = ObjectDataManager.Instance.Get<Monster>(StaticInfos.MainCreatureLightInfos.CreatureGenericId).Grades;
                var mainMonsterGradeData = mainMonsterGrade[StaticInfos.MainCreatureLightInfos.Grade - 1];
                groupLevel += (int)mainMonsterGradeData.Level;
                return groupLevel;
            }
        }

        public string GroupName
        {
            get
            {
                if (StaticInfos.Underlings.Count < 1)
                {
                    return FastD2IReader.Instance.GetText(ObjectDataManager.Instance.Get<Monster>(StaticInfos.MainCreatureLightInfos.CreatureGenericId).NameId);
                }
                var names = new List<string>
                {
                    FastD2IReader.Instance.GetText(ObjectDataManager.Instance.Get<Monster>(StaticInfos.MainCreatureLightInfos.CreatureGenericId).NameId)
                };
                foreach (var monster in StaticInfos.Underlings)
                {
                    names.Add(FastD2IReader.Instance.GetText(ObjectDataManager.Instance.Get<Monster>(monster.CreatureGenericId).NameId));
                }
                var name = string.Empty;
                foreach (var n in names)
                {
                    name += n;
                    if (names.IndexOf(n) != names.Count - 1)
                        name = name + ",";
                }
                return name;
            }
        }

        public int CellId { get; set; }

        public int Id { get; set; }

        public MonsterGroup(GroupMonsterStaticInformations staticInfos, int id, int cellId)
        {
            StaticInfos = staticInfos;
            Id = id;
            CellId = cellId;
        }
    }
}