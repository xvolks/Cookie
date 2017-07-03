using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay;

namespace Cookie.API.Game.Entity
{
    public interface IMonsterGroup : IEntity
    {
        GroupMonsterStaticInformations StaticInfos { get; }

        int MonstersCount { get; }

        int GroupLevel { get; }

        string GroupName { get; }
    }
}