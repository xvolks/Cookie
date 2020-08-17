using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Items
{
    public class ObjectUseOnCellMessage : ObjectUseMessage
    {
        public new const ushort ProtocolId = 3013;

        public ObjectUseOnCellMessage(ushort cells)
        {
            Cells = cells;
        }

        public ObjectUseOnCellMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort Cells { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(Cells);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Cells = reader.ReadVarUhShort();
        }
    }
}