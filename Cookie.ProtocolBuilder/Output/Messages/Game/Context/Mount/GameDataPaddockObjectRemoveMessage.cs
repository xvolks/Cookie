namespace Cookie.API.Protocol.Network.Messages.Game.Context.Mount
{
    using Utils.IO;

    public class GameDataPaddockObjectRemoveMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5993;
        public override ushort MessageID => ProtocolId;
        public ushort CellId { get; set; }

        public GameDataPaddockObjectRemoveMessage(ushort cellId)
        {
            CellId = cellId;
        }

        public GameDataPaddockObjectRemoveMessage() { }

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
