using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeStartOkNpcTradeMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5785;

        public ExchangeStartOkNpcTradeMessage(double npcId)
        {
            NpcId = npcId;
        }

        public ExchangeStartOkNpcTradeMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public double NpcId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(NpcId);
        }

        public override void Deserialize(IDataReader reader)
        {
            NpcId = reader.ReadDouble();
        }
    }
}