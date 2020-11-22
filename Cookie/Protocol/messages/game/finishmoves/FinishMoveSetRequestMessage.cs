using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class FinishMoveSetRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6703;
        public override uint MessageID { get { return ProtocolId; } }

        public int FinishMoveId = 0;
        public bool FinishMoveState = false;

        public FinishMoveSetRequestMessage()
        {
        }

        public FinishMoveSetRequestMessage(
            int finishMoveId,
            bool finishMoveState
        )
        {
            FinishMoveId = finishMoveId;
            FinishMoveState = finishMoveState;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(FinishMoveId);
            writer.WriteBoolean(FinishMoveState);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            FinishMoveId = reader.ReadInt();
            FinishMoveState = reader.ReadBoolean();
        }
    }
}