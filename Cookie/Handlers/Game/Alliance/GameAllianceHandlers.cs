using Cookie.Core;
using Cookie.Protocol.Network.Messages;

namespace Cookie.Handlers.Game.Alliance
{
    public class GameAllianceHandlers
    {
        [MessageHandler(AllianceMotdMessage.ProtocolId)]
        private void AllianceMotdMessageHandler(DofusClient Client, AllianceMotdMessage Message)
        {
            Client.Logger.Log("Annonce d'Alliance : " + Message.Content, LogMessageType.Alliance);
        }
    }
}
