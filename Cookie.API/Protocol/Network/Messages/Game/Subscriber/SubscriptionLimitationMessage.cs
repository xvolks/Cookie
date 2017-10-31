namespace Cookie.API.Protocol.Network.Messages.Game.Subscriber
{
    using Utils.IO;

    public class SubscriptionLimitationMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5542;
        public override ushort MessageID => ProtocolId;
        public byte Reason { get; set; }

        public SubscriptionLimitationMessage(byte reason)
        {
            Reason = reason;
        }

        public SubscriptionLimitationMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Reason);
        }

        public override void Deserialize(IDataReader reader)
        {
            Reason = reader.ReadByte();
        }

    }
}
