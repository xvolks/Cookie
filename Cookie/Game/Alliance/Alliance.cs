using Cookie.API.Core;
using Cookie.API.Game.Alliance;
using Cookie.API.Messages;
using Cookie.API.Protocol.Network.Messages.Game.Alliance;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;

namespace Cookie.Game.Alliance
{
    public class Alliance : IAlliance
    {
        public Alliance(IAccount account)
        {
            account.Network.RegisterPacket<AllianceMotdMessage>(HandleAllianceMotdMessage, MessagePriority.VeryHigh);
        }

        private void HandleAllianceMotdMessage(IAccount account, AllianceMotdMessage message)
        {
            Logger.Default.Log("Annonce d'Alliance : " + message.Content, LogMessageType.Alliance);
        }
    }
}