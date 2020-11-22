using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameContextMoveElementMessage : NetworkMessage
    {
        public const ushort ProtocolId = 253;

        public override ushort MessageID => ProtocolId;

        public EntityMovementInformations Movement { get; set; }
        public GameContextMoveElementMessage() { }

        public GameContextMoveElementMessage( EntityMovementInformations Movement ){
            this.Movement = Movement;
        }

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
