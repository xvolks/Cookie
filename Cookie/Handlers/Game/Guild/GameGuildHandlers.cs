using Cookie.Core;
using Cookie.Protocol.Network.Messages.Game.Guild;

namespace Cookie.Handlers.Game.Guild
{
    public class GameGuildHandlers
    {
        [MessageHandler(GuildMembershipMessage.ProtocolId)]
        private void GuildMembershipMessageHandler(DofusClient Client, GuildMembershipMessage Message)
        {
            //
        }

        [MessageHandler(GuildInformationsGeneralMessage.ProtocolId)]
        private void GuildInformationsGeneralMessageHandler(DofusClient Client, GuildInformationsGeneralMessage Message)
        {
            //
        }

        [MessageHandler(GuildInformationsMembersMessage.ProtocolId)]
        private void GuildInformationsMembersMessageHandler(DofusClient Client, GuildInformationsMembersMessage Message)
        {
            //
        }

        [MessageHandler(GuildMemberOnlineStatusMessage.ProtocolId)]
        private void GuildMemberOnlineStatusMessageHandler(DofusClient Client, GuildMemberOnlineStatusMessage Message)
        {
            //
        }

        [MessageHandler(GuildMotdMessage.ProtocolId)]
        private void GuildMotdMessageHandler(DofusClient Client, GuildMotdMessage Message)
        {
            Client.Logger.Log("Annonce de guilde : " + Message.Content, LogMessageType.Guild);
        }
    }
}
