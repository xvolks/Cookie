using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeBidHouseListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5807;

        public ExchangeBidHouseListMessage(ushort objectId)
        {
            ObjectId = objectId;
        }

        public ExchangeBidHouseListMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort ObjectId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(ObjectId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadVarUhShort();
        }
    }
}