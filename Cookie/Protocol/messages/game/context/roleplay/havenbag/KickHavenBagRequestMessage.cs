using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class KickHavenBagRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6652;
        public override uint MessageID { get { return ProtocolId; } }

        public long GuestId = 0;

        public KickHavenBagRequestMessage()
        {
        }

        public KickHavenBagRequestMessage(
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