using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeBidHouseInListRemovedMessage : NetworkMessage
    {
        public const uint ProtocolId = 5950;
        public override uint MessageID { get { return ProtocolId; } }

        public int ItemUID = 0;

        public ExchangeBidHouseInListRemovedMessage()
        {
        }

        public ExchangeBidHouseInListRemovedMessage(
            int itemUID
        )
        {
            ItemUID = itemUID;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(ItemUID);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ItemUID = reader.ReadInt();
        }
    }
}