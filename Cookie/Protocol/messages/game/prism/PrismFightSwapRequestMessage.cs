using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PrismFightSwapRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 5901;
        public override uint MessageID { get { return ProtocolId; } }

        public short SubAreaId = 0;
        public long TargetId = 0;

        public PrismFightSwapRequestMessage()
        {
        }

        public PrismFightSwapRequestMessage(
            short subAreaId,
            long targetId
        )
        {
            SubAreaId = subAreaId;
            TargetId = targetId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(SubAreaId);
            writer.WriteVarLong(TargetId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            SubAreaId = reader.ReadVarShort();
            TargetId = reader.ReadVarLong();
        }
    }
}