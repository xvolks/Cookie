using Cookie.Core;
using Cookie.Protocol.Network.Messages.Game.Context.Roleplay;

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
            //
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

            foreach (var Actor in Message.Actors)
            {
                if (Actor.ContextualId == Client.Account.Character.Id)
                {
                    Client.Account.Character.CellId = Actor.Disposition.CellId;
                    break;
                }
            } 
        }
    }
}
