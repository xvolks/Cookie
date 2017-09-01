using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Data.Items
{
    public class ObjectItemInformationWithQuantity : ObjectItemMinimalInformation
    {
        public new const ushort ProtocolId = 387;

        public ObjectItemInformationWithQuantity(uint quantity)
        {
            Quantity = quantity;
        }

        public ObjectItemInformationWithQuantity()
        {
        }

        public override ushort TypeID => ProtocolId;
        public uint Quantity { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(Quantity);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Quantity = reader.ReadVarUhInt();
        }
    }
}