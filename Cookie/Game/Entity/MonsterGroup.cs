using System.Collections.Generic;
using System.Linq;
using Cookie.API.Datacenter;
using Cookie.API.Game.Entity;
using Cookie.API.Gamedata.D2i;
using Cookie.API.Gamedata.D2o;
using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay;

namespace Cookie.Game.Entity
{
    public class MonsterGroup : IMonsterGroup
    {
        public MonsterGroup(GroupMonsterStaticInformations staticInfos, double id, int cellId)
        {
            StaticInfos = staticInfos;
            Id = id;
            CellId = cellId;
        }

        public GroupMonsterStaticInformations StaticInfos { get; set; }

        public int MonstersCount => StaticInfos.Underlings.Count + 1;

        public int GroupLevel
        {
            get
            {
                var groupLevel = (from monster in StaticInfos.Underlings
                    let monsterGrade = ObjectDataManager.Instance.Get<Monster>(monster.CreatureGenericId).Grades
                    select monsterGrade[monster.Grade - 1]
                    into monsterGradeData
                    select (int) monsterGradeData.Level).Sum();
                var mainMonsterGrade = ObjectDataManager.Instance
                    .Get<Monster>(StaticInfos.MainCreatureLightInfos.CreatureGenericId).Grades;
                var mainMonsterGradeData = mainMonsterGrade[StaticInfos.MainCreatureLightInfos.Grade - 1];
                groupLevel += (int) mainMonsterGradeData.Level;
                return groupLevel;
            }
        }

        public string GroupName
        {
            get
            {
                if (StaticInfos.Underlings.Count < 1)
                    return FastD2IReader.Instance.GetText(ObjectDataManager.Instance
                        .Get<Monster>(StaticInfos.MainCreatureLightInfos.CreatureGenericId).NameId);
                var names = new List<string>
                {
                    FastD2IReader.Instance.GetText(ObjectDataManager.Instance
                        .Get<Monster>(StaticInfos.MainCreatureLightInfos.CreatureGenericId).NameId)
                };
                names.AddRange(StaticInfos.Underlings.Select(monster => FastD2IReader.Instance.GetText(ObjectDataManager
                    .Instance.Get<Monster>(monster.CreatureGenericId).NameId)));
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

        public double Id { get; set; }
    }
}