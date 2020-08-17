namespace Cookie.API.Protocol.Network.Messages.Game.Context
{
    using Utils.IO;

    public class ShowCellRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5611;
        public override ushort MessageID => ProtocolId;
        public ushort CellId { get; set; }

        public ShowCellRequestMessage(ushort cellId)
        {
            CellId = cellId;
        }

        public ShowCellRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(CellId);
        }

        public override void Deserialize(IDataReader reader)
        {
            CellId = reader.ReadVarUhShort();
        }

    }
}
