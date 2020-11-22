using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class HumanOptionGuild : HumanOption
    {
        public new const short ProtocolId = 409;
        public override short TypeId { get { return ProtocolId; } }

        public GuildInformations GuildInformations_;

        public HumanOptionGuild(): base()
        {
        }

        public HumanOptionGuild(
            GuildInformations guildInformations_
        ): base()
        {
            GuildInformations_ = guildInformations_;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            GuildInformations_.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            GuildInformations_ = new GuildInformations();
            GuildInformations_.Deserialize(reader);
        }
    }
}