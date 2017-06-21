using Cookie.Core;
using Cookie.Protocol.Network.Messages.Game.Context.Roleplay.Objects;

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