using Cookie.API.Network;
using Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay;
using Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Fight.Arena;
using Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Quest;
using Cookie.Core;
using Cookie.Game.Map;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;

namespace Cookie.Handlers.Game.Context.Roleplay
{
    public class GameContextRoleplayHandlers
    {
        [MessageHandler(CurrentMapMessage.ProtocolId)]
        private void CurrentMapMessageHandler(DofusClient client, CurrentMapMessage message)
        {
            client.Account.Character.MapId = message.MapId;
            client.Send(new MapInformationsRequestMessage(message.MapId));
            client.Account.Character.Map = new Map(client) {MapChange = -1};
        }

        [MessageHandler(GameRolePlayShowActorMessage.ProtocolId)]
        private void GameRolePlayShowActorMessageHandler(DofusClient client, GameRolePlayShowActorMessage message)
        {
            client.Account.Character.Map.AddActor(message);
        }

        [MessageHandler(MapFightStartPositionsUpdateMessage.ProtocolId)]
        private void MapFightStartPositionsUpdateMessageHandler(DofusClient client,
            MapFightStartPositionsUpdateMessage message)
        {
            //
        }

        [MessageHandler(MapFightCountMessage.ProtocolId)]
        private void MapFightCountMessageHandler(DofusClient client, MapFightCountMessage message)
        {
            Logger.Default.Log($"Il y a {message.FightCount} combat(s) sur la map.", LogMessageType.Info);
        }

        [MessageHandler(MapComplementaryInformationsDataMessage.ProtocolId)]
        private void MapComplementaryInformationsDataMessageHandler(DofusClient client,
            MapComplementaryInformationsDataMessage message)
        {
            if (client.Account.Character.IsFirstConnection)
            {
                client.Send(new GuidedModeQuitRequestMessage());
                client.Account.Character.IsFirstConnection = false;
            }   

            foreach (var actor in message.Actors)
            {
                if (actor.ContextualId != client.Account.Character.Id) continue;
                client.Account.Character.CellId = actor.Disposition.CellId;
                break;
            }

            client.Account.Character.Map.ParseMapComplementaryInformationsDataMessage(message);

            if (client.Account.Character.GatherManager.Launched)
            {
                client.Account.Character.GatherManager.Gather();
                client.Account.Character.Status = CharacterStatus.Gathering;
            }

            if (client.Account.Character.PathManager.Launched)
                client.Account.Character.PathManager.DoAction();
        }

        [MessageHandler(TeleportOnSameMapMessage.ProtocolId)]
        private void TeleportOnSameMapMessageHandler(DofusClient client, TeleportOnSameMapMessage message)
        {
            Logger.Default.Log($"Un joueur s'est téléporté sur la cellId : {message.CellId}.", LogMessageType.Info);
            client.Account.Character.Map.UpdateEntity(message);
        }
    }
}