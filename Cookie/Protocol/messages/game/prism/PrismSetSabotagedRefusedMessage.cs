using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PrismSetSabotagedRefusedMessage : NetworkMessage
    {
        public const uint ProtocolId = 6466;
        public override uint MessageID { get { return ProtocolId; } }

        public short SubAreaId = 0;
        public byte Reason = 0;

        public PrismSetSabotagedRefusedMessage()
        {
        }

        public PrismSetSabotagedRefusedMessage(
            short subAreaId,
            byte reason
        )
        {
            SubAreaId = subAreaId;
            Reason = reason;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(SubAreaId);
            writer.WriteByte(Reason);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            SubAreaId = reader.ReadVarShort();
            Reason = reader.ReadByte();
        }
    }
}