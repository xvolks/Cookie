namespace Cookie.API.Protocol.Network.Messages.Game.Context.Mount
{
    using Utils.IO;

    public class PaddockMoveItemRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6052;
        public override ushort MessageID => ProtocolId;
        public ushort OldCellId { get; set; }
        public ushort NewCellId { get; set; }

        public PaddockMoveItemRequestMessage(ushort oldCellId, ushort newCellId)
        {
            OldCellId = oldCellId;
            NewCellId = newCellId;
        }

        public PaddockMoveItemRequestMessage() { }

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
