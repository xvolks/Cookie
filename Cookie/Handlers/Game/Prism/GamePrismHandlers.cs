using Cookie.Core;
using Cookie.Protocol.Enums;
using Cookie.Protocol.Network.Messages.Game.Prism;
using Cookie.Utils.Extensions;

namespace Cookie.Handlers.Game.Prism
{
    public class GamePrismHandlers
    {
        [MessageHandler(PrismsListMessage.ProtocolId)]
        private void PrismsListMessageHandler(DofusClient Client, PrismsListMessage Message)
        {
            //Message.Prisms.ForEach(p =>
            //{
            //    Client.Logger.Log($"Prism en [{p.WorldX};{p.WorldY}] | Etat: {(PrismStateEnum)p.Prism.State} | Placé le: {DateExtensions.UnixTimestampToDateTime(p.Prism.PlacementDate).ToShortDateString()}");
            //});
        }

        [MessageHandler(PrismsListUpdateMessage.ProtocolId)]
        private void PrismsListUpdateMessageHandler(DofusClient Client, PrismsListUpdateMessage Message)
        {
            //
        }
    }
}
