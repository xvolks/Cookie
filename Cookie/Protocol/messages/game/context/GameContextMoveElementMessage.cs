using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameContextMoveElementMessage : NetworkMessage
    {
        public const uint ProtocolId = 253;
        public override uint MessageID { get { return ProtocolId; } }

        public EntityMovementInformations Movement;

        public GameContextMoveElementMessage()
        {
        }

        public GameContextMoveElementMessage(
            EntityMovementInformations movement
        )
        {
            Movement = movement;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            Movement.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Movement = new EntityMovementInformations();
            Movement.Deserialize(reader);
        }
    }
}