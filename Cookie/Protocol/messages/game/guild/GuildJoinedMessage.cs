using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildJoinedMessage : NetworkMessage
    {
        public const uint ProtocolId = 5564;
        public override uint MessageID { get { return ProtocolId; } }

        public GuildInformations GuildInfo;
        public int MemberRights = 0;

        public GuildJoinedMessage()
        {
        }

        public GuildJoinedMessage(
            GuildInformations guildInfo,
            int memberRights
        )
        {
            GuildInfo = guildInfo;
            MemberRights = memberRights;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            GuildInfo.Serialize(writer);
            writer.WriteVarInt(MemberRights);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            GuildInfo = new GuildInformations();
            GuildInfo.Deserialize(reader);
            MemberRights = reader.ReadVarInt();
        }
    }
}