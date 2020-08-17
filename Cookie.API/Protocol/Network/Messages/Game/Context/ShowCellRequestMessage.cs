using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context
{
    public class ShowCellRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5611;

        public ShowCellRequestMessage(ushort cellId)
        {
            CellId = cellId;
        }

        public ShowCellRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort CellId { get; set; }

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