using Cookie.Core;
using Cookie.Protocol.Network.Messages.Game.Context;
using Cookie.Protocol.Network.Messages.Game.Context.Roleplay;
using Cookie.Protocol.Network.Types.Game.Context.Roleplay;

namespace Cookie.Handlers.Game.Context.Roleplay
{
    public class GameContextRoleplayHandlers
    {
        [MessageHandler(CurrentMapMessage.ProtocolId)]
        private void CurrentMapMessageHandler(DofusClient Client, CurrentMapMessage Message)
        {
            Client.Account.Character.MapId = Message.MapId;
            Client.Send(new MapInformationsRequestMessage(Message.MapId));
        }

        [MessageHandler(GameRolePlayShowActorMessage.ProtocolId)]
        private void GameRolePlayShowActorMessageHandler(DofusClient Client, GameRolePlayShowActorMessage Message)
        {
            Client.Account.Character.MapData.AddActor(Message.Informations);
        }

        [MessageHandler(MapFightCountMessage.ProtocolId)]
        private void MapFightCountMessageHandler(DofusClient Client, MapFightCountMessage Message)
        {
            Client.Logger.Log($"Il y a {Message.FightCount} combat(s) sur la map.");
        }

        [MessageHandler(MapComplementaryInformationsDataMessage.ProtocolId)]
        private void MapComplementaryInformationsDataMessageHandler(DofusClient Client, MapComplementaryInformationsDataMessage Message)
        {
            Client.Account.Character.MapId = Message.MapId;
            Client.Account.Character.MapData.Clear();
            Client.Account.Character.MapData.ParseLocation(Message.MapId);
            Client.Account.Character.MapData.ParseActors(Message.Actors.ToArray());

            foreach (var Actor in Message.Actors)
            {
                if (Actor.ContextualId != Client.Account.Character.Id) continue;
                Client.Account.Character.CellId = Actor.Disposition.CellId;
                break;
            }
        }
    }
}