namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Items
{
    using Utils.IO;

    public class ObtainedItemMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6519;
        public override ushort MessageID => ProtocolId;
        public ushort GenericId { get; set; }
        public uint BaseQuantity { get; set; }

        public ObtainedItemMessage(ushort genericId, uint baseQuantity)
        {
            GenericId = genericId;
            BaseQuantity = baseQuantity;
        }

        public ObtainedItemMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(GenericId);
            writer.WriteVarUhInt(BaseQuantity);
        }

        public override void Deserialize(IDataReader reader)
        {
            GenericId = reader.ReadVarUhShort();
            BaseQuantity = reader.ReadVarUhInt();
        }

    }
}
