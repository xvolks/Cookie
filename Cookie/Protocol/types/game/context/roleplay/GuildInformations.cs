using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class GuildInformations : BasicGuildInformations
    {
        public new const short ProtocolId = 127;
        public override short TypeId { get { return ProtocolId; } }

        public GuildEmblem GuildEmblem_;

        public GuildInformations(): base()
        {
        }

        public GuildInformations(
            int guildId,
            string guildName,
            byte guildLevel,
            GuildEmblem guildEmblem_
        ): base(
            guildId,
            guildName,
            guildLevel
        )
        {
            GuildEmblem_ = guildEmblem_;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            GuildEmblem_.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            GuildEmblem_ = new GuildEmblem();
            GuildEmblem_.Deserialize(reader);
        }
    }
}