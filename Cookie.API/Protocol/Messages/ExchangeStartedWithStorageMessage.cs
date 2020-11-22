using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeStartedWithStorageMessage : ExchangeStartedMessage
    {
        public new const ushort ProtocolId = 6236;

        public override ushort MessageID => ProtocolId;

        public uint StorageMaxSlot { get; set; }
        public ExchangeStartedWithStorageMessage() { }

        public ExchangeStartedWithStorageMessage( uint StorageMaxSlot ){
            this.StorageMaxSlot = StorageMaxSlot;
        }

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
