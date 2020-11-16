using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class PaddockGuildedInformations : PaddockBuyableInformations
    {
        public new const short ProtocolId = 508;
        public override short TypeId { get { return ProtocolId; } }

        public bool Deserted = false;
        public GuildInformations GuildInfo;

        public PaddockGuildedInformations(): base()
        {
        }

        public PaddockGuildedInformations(
            long price,
            bool locked,
            bool deserted,
            GuildInformations guildInfo
        ): base(
            price,
            locked
        )
        {
            Deserted = deserted;
            GuildInfo = guildInfo;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(Deserted);
            GuildInfo.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Deserted = reader.ReadBoolean();
            GuildInfo = new GuildInformations();
            GuildInfo.Deserialize(reader);
        }
    }
}