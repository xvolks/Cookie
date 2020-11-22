using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class StorageKamasUpdateMessage : NetworkMessage
    {
        public const uint ProtocolId = 5645;
        public override uint MessageID { get { return ProtocolId; } }

        public long KamasTotal = 0;

        public StorageKamasUpdateMessage()
        {
        }

        public StorageKamasUpdateMessage(
            long kamasTotal
        )
        {
            KamasTotal = kamasTotal;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarLong(KamasTotal);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            KamasTotal = reader.ReadVarLong();
        }
    }
}