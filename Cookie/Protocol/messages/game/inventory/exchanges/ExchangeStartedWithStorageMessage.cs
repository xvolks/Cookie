using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeStartedWithStorageMessage : ExchangeStartedMessage
    {
        public new const uint ProtocolId = 6236;
        public override uint MessageID { get { return ProtocolId; } }

        public int StorageMaxSlot = 0;

        public ExchangeStartedWithStorageMessage(): base()
        {
        }

        public ExchangeStartedWithStorageMessage(
            byte exchangeType,
            int storageMaxSlot
        ): base(
            exchangeType
        )
        {
            StorageMaxSlot = storageMaxSlot;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarInt(StorageMaxSlot);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            StorageMaxSlot = reader.ReadVarInt();
        }
    }
}