namespace Cookie.API.Protocol.Network.Messages.Subscription
{
    using Utils.IO;

    public class SubscriptionUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6616;
        public override ushort MessageID => ProtocolId;
        public double Timestamp { get; set; }

        public SubscriptionUpdateMessage(double timestamp)
        {
            Timestamp = timestamp;
        }

        public SubscriptionUpdateMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(Timestamp);
        }

        public override void Deserialize(IDataReader reader)
        {
            Timestamp = reader.ReadDouble();
        }

    }
}
