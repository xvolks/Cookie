using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeBidHouseInListRemovedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5950;

        public ExchangeBidHouseInListRemovedMessage(int itemUID)
        {
            ItemUID = itemUID;
        }

        public ExchangeBidHouseInListRemovedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public int ItemUID { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(ItemUID);
        }

        public override void Deserialize(IDataReader reader)
        {
            ItemUID = reader.ReadInt();
        }
    }
}