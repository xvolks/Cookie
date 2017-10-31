namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Utils.IO;

    public class ExchangeStartedWithStorageMessage : ExchangeStartedMessage
    {
        public new const ushort ProtocolId = 6236;
        public override ushort MessageID => ProtocolId;
        public uint StorageMaxSlot { get; set; }

        public ExchangeStartedWithStorageMessage(uint storageMaxSlot)
        {
            StorageMaxSlot = storageMaxSlot;
        }

        public ExchangeStartedWithStorageMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(StorageMaxSlot);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            StorageMaxSlot = reader.ReadVarUhInt();
        }

    }
}
