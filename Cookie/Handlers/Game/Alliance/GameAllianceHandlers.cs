using Cookie.API.Network;
using Cookie.Core;
using Cookie.API.Protocol.Network.Messages.Game.Alliance;

namespace Cookie.Handlers.Game.Alliance
{
    public class GameAllianceHandlers
    {
        [MessageHandler(AllianceMotdMessage.ProtocolId)]
        private void AllianceMotdMessageHandler(DofusClient client, AllianceMotdMessage message)
        {
            client.Logger.Log("Annonce d'Alliance : " + message.Content, LogMessageType.Alliance);
        }
    }
}