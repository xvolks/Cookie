using Cookie.Core;
using Cookie.Protocol.Network.Messages.Game.Context.Roleplay.Emote;

namespace Cookie.Handlers.Game.Context.Roleplay.Emote
{
    public class GameContextRoleplayEmoteHandlers
    {
        [MessageHandler(EmoteListMessage.ProtocolId)]
        private void EmoteListMessageHandler(DofusClient client, EmoteListMessage message)
        {
            //
        }
    }
}
