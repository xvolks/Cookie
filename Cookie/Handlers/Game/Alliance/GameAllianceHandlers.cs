using Cookie.API.Network;
using Cookie.API.Protocol.Network.Messages.Game.Alliance;
using Cookie.Core;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;

namespace Cookie.Handlers.Game.Alliance
{
    public class GameAllianceHandlers
    {
        [MessageHandler(AllianceMotdMessage.ProtocolId)]
        private void AllianceMotdMessageHandler(DofusClient client, AllianceMotdMessage message)
        {
            Logger.Default.Log("Annonce d'Alliance : " + message.Content, LogMessageType.Alliance);
        }
    }
}