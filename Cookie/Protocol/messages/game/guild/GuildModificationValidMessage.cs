using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildModificationValidMessage : NetworkMessage
    {
        public const uint ProtocolId = 6323;
        public override uint MessageID { get { return ProtocolId; } }

        public string GuildName;
        public GuildEmblem GuildEmblem_;

        public GuildModificationValidMessage()
        {
        }

        public GuildModificationValidMessage(
            string guildName,
            GuildEmblem guildEmblem_
        )
        {
            GuildName = guildName;
            GuildEmblem_ = guildEmblem_;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteUTF(GuildName);
            GuildEmblem_.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            GuildName = reader.ReadUTF();
            GuildEmblem_ = new GuildEmblem();
            GuildEmblem_.Deserialize(reader);
        }
    }
}