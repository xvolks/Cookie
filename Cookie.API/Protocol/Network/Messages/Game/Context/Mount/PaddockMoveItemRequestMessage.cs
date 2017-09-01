using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Mount
{
    public class PaddockMoveItemRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6052;

        public PaddockMoveItemRequestMessage(ushort oldCellId, ushort newCellId)
        {
            OldCellId = oldCellId;
            NewCellId = newCellId;
        }

        public PaddockMoveItemRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort OldCellId { get; set; }
        public ushort NewCellId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(OldCellId);
            writer.WriteVarUhShort(NewCellId);
        }

        public override void Deserialize(IDataReader reader)
        {
            OldCellId = reader.ReadVarUhShort();
            NewCellId = reader.ReadVarUhShort();
        }
    }
}