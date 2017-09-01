using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Subscriber
{
    public class SubscriptionLimitationMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5542;

        public SubscriptionLimitationMessage(byte reason)
        {
            Reason = reason;
        }

        public SubscriptionLimitationMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte Reason { get; set; }

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