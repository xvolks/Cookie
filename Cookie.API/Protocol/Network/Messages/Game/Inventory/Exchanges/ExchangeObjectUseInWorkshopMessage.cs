namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Utils.IO;

    public class ExchangeObjectUseInWorkshopMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6004;
        public override ushort MessageID => ProtocolId;
        public uint ObjectUID { get; set; }
        public int Quantity { get; set; }

        public ExchangeObjectUseInWorkshopMessage(uint objectUID, int quantity)
        {
            ObjectUID = objectUID;
            Quantity = quantity;
        }

        public ExchangeObjectUseInWorkshopMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(ObjectUID);
            writer.WriteVarInt(Quantity);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectUID = reader.ReadVarUhInt();
            Quantity = reader.ReadVarInt();
        }

    }
}
