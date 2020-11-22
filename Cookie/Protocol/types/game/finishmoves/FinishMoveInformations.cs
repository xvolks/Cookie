using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class FinishMoveInformations : NetworkType
    {
        public const short ProtocolId = 506;
        public override short TypeId { get { return ProtocolId; } }

        public int FinishMoveId = 0;
        public bool FinishMoveState = false;

        public FinishMoveInformations()
        {
        }

        public FinishMoveInformations(
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