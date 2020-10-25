using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class SubscriptionZoneMessage : NetworkMessage
    {
        public const uint ProtocolId = 5573;
        public override uint MessageID { get { return ProtocolId; } }

        public bool Active = false;

        public SubscriptionZoneMessage()
        {
        }

        public SubscriptionZoneMessage(
            bool active
        )
        {
            Active = active;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteBoolean(Active);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Active = reader.ReadBoolean();
        }
    }
}