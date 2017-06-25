using Cookie.API.Network;
using Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Objects;
using Cookie.Core;

namespace Cookie.Handlers.Game.Context.Roleplay.Objects
{
    public class GameContextRoleplayObjectsHandlers
    {
        [MessageHandler(ObjectGroundListAddedMessage.ProtocolId)]
        private void ObjectGroundListAddedMessageHandler(DofusClient client, ObjectGroundListAddedMessage message)
        {
            //
        }
    }
}