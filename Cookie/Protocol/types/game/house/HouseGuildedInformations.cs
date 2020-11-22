using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class HouseGuildedInformations : HouseInstanceInformations
    {
        public new const short ProtocolId = 512;
        public override short TypeId { get { return ProtocolId; } }

        public GuildInformations GuildInfo;

        public HouseGuildedInformations(): base()
        {
        }

        public HouseGuildedInformations(
            bool secondHand,
            bool isLocked,
            bool isSaleLocked,
            int instanceId,
            string ownerName,
            long price,
            GuildInformations guildInfo
        ): base(
            secondHand,
            isLocked,
            isSaleLocked,
            instanceId,
            ownerName,
            price
        )
        {
            GuildInfo = guildInfo;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            GuildInfo.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            GuildInfo = new GuildInformations();
            GuildInfo.Deserialize(reader);
        }
    }
}