using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GuestModeMessage : NetworkMessage
    {
        public const uint ProtocolId = 6505;
        public override uint MessageID { get { return ProtocolId; } }

        public bool Active = false;

        public GuestModeMessage()
        {
        }

        public GuestModeMessage(
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