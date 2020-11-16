using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildModificationEmblemValidMessage : NetworkMessage
    {
        public const uint ProtocolId = 6328;
        public override uint MessageID { get { return ProtocolId; } }

        public GuildEmblem GuildEmblem_;

        public GuildModificationEmblemValidMessage()
        {
        }

        public GuildModificationEmblemValidMessage(
            GuildEmblem guildEmblem_
        )
        {
            GuildEmblem_ = guildEmblem_;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            GuildEmblem_.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            GuildEmblem_ = new GuildEmblem();
            GuildEmblem_.Deserialize(reader);
        }
    }
}