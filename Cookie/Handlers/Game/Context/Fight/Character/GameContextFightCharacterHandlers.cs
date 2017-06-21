using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cookie.Core;
using Cookie.Protocol.Network.Messages.Game.Context.Fight.Character;

namespace Cookie.Handlers.Game.Context.Fight.Character
{
    public class GameContextFightCharacterHandlers
    {
        [MessageHandler(GameFightShowFighterMessage.ProtocolId)]
        private void GameFightShowFighterMessageHandler(DofusClient client, GameFightShowFighterMessage message)
        {
            if (message.Informations.ContextualId == client.Account.Character.Id)
                client.Logger.Log("Vous êtes entré dans un combat !", LogMessageType.Info);
        }
    }
}
