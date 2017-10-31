namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Utils.IO;

    public class ExchangeStartOkNpcTradeMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5785;
        public override ushort MessageID => ProtocolId;
        public double NpcId { get; set; }

        public ExchangeStartOkNpcTradeMessage(double npcId)
        {
            NpcId = npcId;
        }

        public ExchangeStartOkNpcTradeMessage() { }

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
