using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildMemberLeavingMessage : NetworkMessage
    {
        public const uint ProtocolId = 5923;
        public override uint MessageID { get { return ProtocolId; } }

        public bool Kicked = false;
        public long MemberId = 0;

        public GuildMemberLeavingMessage()
        {
        }

        public GuildMemberLeavingMessage(
            bool kicked,
            long memberId
        )
        {
            Kicked = kicked;
            MemberId = memberId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteBoolean(Kicked);
            writer.WriteVarLong(MemberId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Kicked = reader.ReadBoolean();
            MemberId = reader.ReadVarLong();
        }
    }
}