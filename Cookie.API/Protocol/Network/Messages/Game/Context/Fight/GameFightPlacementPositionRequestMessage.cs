namespace Cookie.API.Protocol.Network.Messages.Game.Context.Fight
{
    using Utils.IO;

    public class GameFightPlacementPositionRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 704;
        public override ushort MessageID => ProtocolId;
        public ushort CellId { get; set; }

        public GameFightPlacementPositionRequestMessage(ushort cellId)
        {
            CellId = cellId;
        }

        public GameFightPlacementPositionRequestMessage() { }

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
