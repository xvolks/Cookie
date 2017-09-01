using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeObjectMoveMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5518;

        public ExchangeObjectMoveMessage(uint objectUID, int quantity)
        {
            ObjectUID = objectUID;
            Quantity = quantity;
        }

        public ExchangeObjectMoveMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public uint ObjectUID { get; set; }
        public int Quantity { get; set; }

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