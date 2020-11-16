using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildMemberOnlineStatusMessage : NetworkMessage
    {
        public const uint ProtocolId = 6061;
        public override uint MessageID { get { return ProtocolId; } }

        public long MemberId = 0;
        public bool Online = false;

        public GuildMemberOnlineStatusMessage()
        {
        }

        public GuildMemberOnlineStatusMessage(
            long memberId,
            bool online
        )
        {
            MemberId = memberId;
            Online = online;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarLong(MemberId);
            writer.WriteBoolean(Online);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            MemberId = reader.ReadVarLong();
            Online = reader.ReadBoolean();
        }
    }
}