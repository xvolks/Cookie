using Cookie.Core;
using Cookie.Protocol.Network.Messages;

namespace Cookie.Handlers.Game.Context.Roleplay.Emote
{
    public class GameContextRoleplayEmoteHandlers
    {
        [MessageHandler(EmoteListMessage.ProtocolId)]
        private void EmoteListMessageHandler(DofusClient Client, EmoteListMessage Message)
        {
            //
        }
    }
}
