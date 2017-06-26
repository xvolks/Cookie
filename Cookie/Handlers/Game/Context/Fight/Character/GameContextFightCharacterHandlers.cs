using Cookie.API.Network;
using Cookie.API.Protocol.Network.Messages.Game.Context.Fight.Character;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;
using Cookie.Core;

namespace Cookie.Handlers.Game.Context.Fight.Character
{
    public class GameContextFightCharacterHandlers
    {
        [MessageHandler(GameFightShowFighterMessage.ProtocolId)]
        private void GameFightShowFighterMessageHandler(DofusClient client, GameFightShowFighterMessage message)
        {
            if (message.Informations.ContextualId == client.Account.Character.Id)
                Logger.Default.Log("Vous êtes entré dans un combat !", LogMessageType.Info);
        }
    }
}