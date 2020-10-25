using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class AllianceVersatileInformations : NetworkType
    {
        public const short ProtocolId = 432;
        public override short TypeId { get { return ProtocolId; } }

        public int AllianceId = 0;
        public short NbGuilds = 0;
        public short NbMembers = 0;
        public short NbSubarea = 0;

        public AllianceVersatileInformations()
        {
        }

        public AllianceVersatileInformations(
            int allianceId,
            short nbGuilds,
            short nbMembers,
            short nbSubarea
        )
        {
            AllianceId = allianceId;
            NbGuilds = nbGuilds;
            NbMembers = nbMembers;
            NbSubarea = nbSubarea;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(AllianceId);
            writer.WriteVarShort(NbGuilds);
            writer.WriteVarShort(NbMembers);
            writer.WriteVarShort(NbSubarea);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            AllianceId = reader.ReadVarInt();
            NbGuilds = reader.ReadVarShort();
            NbMembers = reader.ReadVarShort();
            NbSubarea = reader.ReadVarShort();
        }
    }
}