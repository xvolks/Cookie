using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class GuildInAllianceVersatileInformations : GuildVersatileInformations
    {
        public new const short ProtocolId = 437;
        public override short TypeId { get { return ProtocolId; } }

        public int AllianceId = 0;

        public GuildInAllianceVersatileInformations(): base()
        {
        }

        public GuildInAllianceVersatileInformations(
            int guildId,
            long leaderId,
            byte guildLevel,
            byte nbMembers,
            int allianceId
        ): base(
            guildId,
            leaderId,
            guildLevel,
            nbMembers
        )
        {
            AllianceId = allianceId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarInt(AllianceId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            AllianceId = reader.ReadVarInt();
        }
    }
}