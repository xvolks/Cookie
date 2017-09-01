using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Subscriber
{
    public class SubscriptionZoneMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5573;

        public SubscriptionZoneMessage(bool active)
        {
            Active = active;
        }

        public SubscriptionZoneMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool Active { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Active);
        }

        public override void Deserialize(IDataReader reader)
        {
            Active = reader.ReadBoolean();
        }
    }
}