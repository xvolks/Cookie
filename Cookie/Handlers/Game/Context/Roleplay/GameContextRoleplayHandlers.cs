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
            client.Logger.Log($"Il y a {message.FightCount} combat(s) sur la map.", LogMessageType.Info);
        }

        [MessageHandler(MapComplementaryInformationsDataMessage.ProtocolId)]
        private void MapComplementaryInformationsDataMessageHandler(DofusClient client,
            MapComplementaryInformationsDataMessage message)
        {
            foreach (var actor in message.Actors)
            {
                if (actor.ContextualId != client.Account.Character.Id) continue;
                client.Account.Character.CellId = actor.Disposition.CellId;
                break;
            }

            client.Account.Character.MapId = message.MapId;
            client.Account.Character.MapData.Clear();
            client.Account.Character.GatherManager.BannedElementId.Clear();
            client.Account.Character.MapData.ParseLocation(message.MapId);
            client.Account.Character.MapData.ParseActors(message.Actors.ToArray());
            client.Account.Character.MapData.ParseInteractiveElement(message.InteractiveElements.ToArray());
            client.Account.Character.MapData.ParseStatedElement(message.StatedElements.ToArray());
        }

        [MessageHandler(TeleportOnSameMapMessage.ProtocolId)]
        private void TeleportOnSameMapMessageHandler(DofusClient client, TeleportOnSameMapMessage message)
        {
            client.Logger.Log($"Un joueur s'est téléporté sur la cellId : {message.CellId}.", LogMessageType.Info);
        }
    }
}