using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class TeleportOnSameMapMessage : NetworkMessage
    {
        public const uint ProtocolId = 6048;
        public override uint MessageID { get { return ProtocolId; } }

        public double TargetId = 0;
        public short CellId = 0;

        public TeleportOnSameMapMessage()
        {
        }

        public TeleportOnSameMapMessage(
            double targetId,
            short cellId
        )
        {
            TargetId = targetId;
            CellId = cellId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(TargetId);
            writer.WriteVarShort(CellId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            TargetId = reader.ReadDouble();
            CellId = reader.ReadVarShort();
        }
    }
}