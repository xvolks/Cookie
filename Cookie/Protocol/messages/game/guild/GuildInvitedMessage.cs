using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildInvitedMessage : NetworkMessage
    {
        public const uint ProtocolId = 5552;
        public override uint MessageID { get { return ProtocolId; } }

        public long RecruterId = 0;
        public string RecruterName;
        public BasicGuildInformations GuildInfo;

        public GuildInvitedMessage()
        {
        }

        public GuildInvitedMessage(
            long recruterId,
            string recruterName,
            BasicGuildInformations guildInfo
        )
        {
            RecruterId = recruterId;
            RecruterName = recruterName;
            GuildInfo = guildInfo;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarLong(RecruterId);
            writer.WriteUTF(RecruterName);
            GuildInfo.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            RecruterId = reader.ReadVarLong();
            RecruterName = reader.ReadUTF();
            GuildInfo = new BasicGuildInformations();
            GuildInfo.Deserialize(reader);
        }
    }
}