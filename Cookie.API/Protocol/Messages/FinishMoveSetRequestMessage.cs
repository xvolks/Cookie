using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class FinishMoveSetRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6703;

        public override ushort MessageID => ProtocolId;

        public int FinishMoveId { get; set; }
        public bool FinishMoveState { get; set; }
        public FinishMoveSetRequestMessage() { }

        public FinishMoveSetRequestMessage( int FinishMoveId, bool FinishMoveState ){
            this.FinishMoveId = FinishMoveId;
            this.FinishMoveState = FinishMoveState;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(FinishMoveId);
            writer.WriteBoolean(FinishMoveState);
        }

        public override void Deserialize(IDataReader reader)
        {
            FinishMoveId = reader.ReadInt();
            FinishMoveState = reader.ReadBoolean();
        }
    }
}
