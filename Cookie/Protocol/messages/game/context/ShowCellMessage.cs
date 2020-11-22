using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ShowCellMessage : NetworkMessage
    {
        public const uint ProtocolId = 5612;
        public override uint MessageID { get { return ProtocolId; } }

        public double SourceId = 0;
        public short CellId = 0;

        public ShowCellMessage()
        {
        }

        public ShowCellMessage(
            double sourceId,
            short cellId
        )
        {
            SourceId = sourceId;
            CellId = cellId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(SourceId);
            writer.WriteVarShort(CellId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            SourceId = reader.ReadDouble();
            CellId = reader.ReadVarShort();
        }
    }
}