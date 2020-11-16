using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AllianceKickRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6400;
        public override uint MessageID { get { return ProtocolId; } }

        public int KickedId = 0;

        public AllianceKickRequestMessage()
        {
        }

        public AllianceKickRequestMessage(
            int kickedId
        )
        {
            KickedId = kickedId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(KickedId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            KickedId = reader.ReadVarInt();
        }
    }
}