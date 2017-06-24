using Cookie.API.Network;
using Cookie.Core;
using Cookie.API.Protocol.Network.Messages.Game.Prism;

namespace Cookie.Handlers.Game.Prism
{
    public class GamePrismHandlers
    {
        [MessageHandler(PrismsListMessage.ProtocolId)]
        private void PrismsListMessageHandler(DofusClient client, PrismsListMessage message)
        {
            //message.Prisms.ForEach(p => Client.Logger.Log($"Prism: Alliance({p.AllianceId}) SubArea({p.SubAreaId})"));
        }

        [MessageHandler(PrismsListUpdateMessage.ProtocolId)]
        private void PrismsListUpdateMessageHandler(DofusClient client, PrismsListUpdateMessage message)
        {
            //
        }
    }
}