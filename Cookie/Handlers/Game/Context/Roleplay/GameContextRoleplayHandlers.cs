using Cookie.Core;
using Cookie.Protocol.Network.Messages.Game.Context.Roleplay;

namespace Cookie.Handlers.Game.Context.Roleplay
{
    public class GameContextRoleplayHandlers
    {
        [MessageHandler(CurrentMapMessage.ProtocolId)]
        private void CurrentMapMessageHandler(DofusClient client, CurrentMapMessage message)
        {
            client.Account.Character.MapId = message.MapId;
            client.Send(new MapInformationsRequestMessage(message.MapId));
        }

        [MessageHandler(GameRolePlayShowActorMessage.ProtocolId)]
        private void GameRolePlayShowActorMessageHandler(DofusClient client, GameRolePlayShowActorMessage message)
        {
            client.Account.Character.MapData.AddActor(message.Informations);
        }

        [MessageHandler(MapFightCountMessage.ProtocolId)]
        private void MapFightCountMessageHandler(DofusClient client, MapFightCountMessage message)
        {
            client.Logger.Log($"Il y a {message.FightCount} combat(s) sur la map.");
        }

        [MessageHandler(MapComplementaryInformationsDataMessage.ProtocolId)]
        private void MapComplementaryInformationsDataMessageHandler(DofusClient client, MapComplementaryInformationsDataMessage Message)
        {
            client.Account.Character.MapId = Message.MapId;
            client.Account.Character.MapData.Clear();
            client.Account.Character.MapData.ParseLocation(Message.MapId);
            client.Account.Character.MapData.ParseActors(Message.Actors.ToArray());
            client.Account.Character.Pathfinder.SetMap(client.Account.Character.MapData, true);

            foreach (var Actor in Message.Actors)
            {
                if (Actor.ContextualId != client.Account.Character.Id) continue;
                client.Account.Character.CellId = Actor.Disposition.CellId;
                break;
            }
        }
    }
}