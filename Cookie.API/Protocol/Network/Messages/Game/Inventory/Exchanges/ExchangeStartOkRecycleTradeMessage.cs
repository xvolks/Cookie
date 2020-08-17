using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    public class ExchangeStartOkRecycleTradeMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6600;

        public ExchangeStartOkRecycleTradeMessage(short percentToPrism, short percentToPlayer)
        {
            PercentToPrism = percentToPrism;
            PercentToPlayer = percentToPlayer;
        }

        public ExchangeStartOkRecycleTradeMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public short PercentToPrism { get; set; }
        public short PercentToPlayer { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(PercentToPrism);
            writer.WriteShort(PercentToPlayer);
        }

        public override void Deserialize(IDataReader reader)
        {
            PercentToPrism = reader.ReadShort();
            PercentToPlayer = reader.ReadShort();
        }
    }
}