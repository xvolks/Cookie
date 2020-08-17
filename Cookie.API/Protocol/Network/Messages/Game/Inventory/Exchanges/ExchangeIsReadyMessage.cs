namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using Utils.IO;

    public class ExchangeIsReadyMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5509;
        public override ushort MessageID => ProtocolId;
        public double ObjectId { get; set; }
        public bool Ready { get; set; }

        public ExchangeIsReadyMessage(double objectId, bool ready)
        {
            ObjectId = objectId;
            Ready = ready;
        }

        public ExchangeIsReadyMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(ObjectId);
            writer.WriteBoolean(Ready);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadDouble();
            Ready = reader.ReadBoolean();
        }

    }
}
