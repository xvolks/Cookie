using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Social
{
    public class AllianceVersatileInformations : NetworkType
    {
        public const ushort ProtocolId = 432;

        public AllianceVersatileInformations(uint allianceId, ushort nbGuilds, ushort nbMembers, ushort nbSubarea)
        {
            AllianceId = allianceId;
            NbGuilds = nbGuilds;
            NbMembers = nbMembers;
            NbSubarea = nbSubarea;
        }

        public AllianceVersatileInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public uint AllianceId { get; set; }
        public ushort NbGuilds { get; set; }
        public ushort NbMembers { get; set; }
        public ushort NbSubarea { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(AllianceId);
            writer.WriteVarUhShort(NbGuilds);
            writer.WriteVarUhShort(NbMembers);
            writer.WriteVarUhShort(NbSubarea);
        }

        public override void Deserialize(IDataReader reader)
        {
            AllianceId = reader.ReadVarUhInt();
            NbGuilds = reader.ReadVarUhShort();
            NbMembers = reader.ReadVarUhShort();
            NbSubarea = reader.ReadVarUhShort();
        }
    }
}