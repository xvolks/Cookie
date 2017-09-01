using Cookie.API.Protocol.Network.Types.Game.Context;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context
{
    public class GameContextMoveElementMessage : NetworkMessage
    {
        public const ushort ProtocolId = 253;

        public GameContextMoveElementMessage(EntityMovementInformations movement)
        {
            Movement = movement;
        }

        public GameContextMoveElementMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public EntityMovementInformations Movement { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            Movement.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Movement = new EntityMovementInformations();
            Movement.Deserialize(reader);
        }
    }
}