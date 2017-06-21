using Cookie.Core;
using Cookie.Protocol.Network.Messages.Game.Guild;

namespace Cookie.Handlers.Game.Guild
{
    public class GameGuildHandlers
    {
        [MessageHandler(GuildMembershipMessage.ProtocolId)]
        private void GuildMembershipMessageHandler(DofusClient client, GuildMembershipMessage message)
        {
            //
        }

        [MessageHandler(GuildInformationsGeneralMessage.ProtocolId)]
        private void GuildInformationsGeneralMessageHandler(DofusClient client, GuildInformationsGeneralMessage message)
        {
            //
        }

        [MessageHandler(GuildInformationsMembersMessage.ProtocolId)]
        private void GuildInformationsMembersMessageHandler(DofusClient client, GuildInformationsMembersMessage message)
        {
            //
        }

        [MessageHandler(GuildMemberOnlineStatusMessage.ProtocolId)]
        private void GuildMemberOnlineStatusMessageHandler(DofusClient client, GuildMemberOnlineStatusMessage message)
        {
            //
        }

        [MessageHandler(GuildMotdMessage.ProtocolId)]
        private void GuildMotdMessageHandler(DofusClient client, GuildMotdMessage message)
        {
            client.Logger.Log("Annonce de guilde : " + message.Content, LogMessageType.Guild);
        }
    }
}