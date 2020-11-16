using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PaddockMoveItemRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6052;
        public override uint MessageID { get { return ProtocolId; } }

        public short OldCellId = 0;
        public short NewCellId = 0;

        public PaddockMoveItemRequestMessage()
        {
        }

        public PaddockMoveItemRequestMessage(
            short oldCellId,
            short newCellId
        )
        {
            OldCellId = oldCellId;
            NewCellId = newCellId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(OldCellId);
            writer.WriteVarShort(NewCellId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            OldCellId = reader.ReadVarShort();
            NewCellId = reader.ReadVarShort();
        }
    }
}