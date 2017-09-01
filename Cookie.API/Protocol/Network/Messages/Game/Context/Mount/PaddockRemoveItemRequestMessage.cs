using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Mount
{
    public class PaddockRemoveItemRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5958;

        public PaddockRemoveItemRequestMessage(ushort cellId)
        {
            CellId = cellId;
        }

        public PaddockRemoveItemRequestMessage()
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