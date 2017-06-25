using Cookie.API.Protocol.Network.Messages.Game.Interactive;
using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay;
using Cookie.API.Protocol.Network.Types.Game.Interactive;
using System.Collections.Generic;

namespace Cookie.API.Game.Map
{
    public interface IMapData
    {
        Gamedata.D2p.IMap Data { get; set; }

        List<GameRolePlayCharacterInformations> Players { get; set; }

        List<GameRolePlayGroupMonsterInformations> Monsters { get; set; }

        List<GameRolePlayNpcInformations> Npcs { get; set; }

        List<GameRolePlayActorInformations> Others { get; set; }

        List<InteractiveElement> InteractiveElements { get; set; }

        List<StatedElement> StatedElements { get; set; }

        void ParseLocation(int mapId);

        void ParseActors(GameRolePlayActorInformations[] actors);
        void AddActor(GameRolePlayActorInformations actor);
        void RemoveActor(double contextualId);
        void RefreshActor(double contextualId, short cellEnd);

        void ParseInteractiveElement(InteractiveElement[] elements);
        void ParseStatedElement(StatedElement[] elements);

        void UpdateInteractiveElement(InteractiveElementUpdatedMessage update);

        void UpdateStatedElement(StatedElementUpdatedMessage update);

        bool NoEntitiesOnCell(int cellId);

        bool NothingOnCell(int cellId);

        void Clear();
    }
}
