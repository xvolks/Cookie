using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeStartedWithStorageMessage : ExchangeStartedMessage
    {
        public new const ushort ProtocolId = 6236;

        public ExchangeStartedWithStorageMessage(uint storageMaxSlot)
        {
            StorageMaxSlot = storageMaxSlot;
        }

        public ExchangeStartedWithStorageMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public uint StorageMaxSlot { get; set; }

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