namespace Cookie.API.Protocol.Network.Messages.Game.Context
{
    using Utils.IO;

    public class GameMapMovementCancelMessage : NetworkMessage
    {
        public const ushort ProtocolId = 953;
        public override ushort MessageID => ProtocolId;
        public ushort CellId { get; set; }

        public GameMapMovementCancelMessage(ushort cellId)
        {
            CellId = cellId;
        }

        public GameMapMovementCancelMessage() { }

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
