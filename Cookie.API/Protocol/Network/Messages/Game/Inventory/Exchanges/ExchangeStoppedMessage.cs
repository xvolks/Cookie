using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeStoppedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6589;

        public ExchangeStoppedMessage(ulong objectId)
        {
            ObjectId = objectId;
        }

        public ExchangeStoppedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ulong ObjectId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(ObjectId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadVarUhLong();
        }
    }
}