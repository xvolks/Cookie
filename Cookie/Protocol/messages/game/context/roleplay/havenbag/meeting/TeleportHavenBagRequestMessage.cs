using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class TeleportHavenBagRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6647;
        public override uint MessageID { get { return ProtocolId; } }

        public long GuestId = 0;

        public TeleportHavenBagRequestMessage()
        {
        }

        public TeleportHavenBagRequestMessage(
            long guestId
        )
        {
            GuestId = guestId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarLong(GuestId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            GuestId = reader.ReadVarLong();
        }
    }
}