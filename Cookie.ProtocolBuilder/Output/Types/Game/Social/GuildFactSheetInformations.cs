namespace Cookie.API.Protocol.Network.Types.Game.Social
{
    using Types.Game.Context.Roleplay;
    using Types.Game.Guild;
    using Utils.IO;

    public class GuildFactSheetInformations : GuildInformations
    {
        public new const ushort ProtocolId = 424;
        public override ushort TypeID => ProtocolId;
        public ulong LeaderId { get; set; }
        public ushort NbMembers { get; set; }

        public GuildFactSheetInformations(ulong leaderId, ushort nbMembers)
        {
            LeaderId = leaderId;
            NbMembers = nbMembers;
        }

        public GuildFactSheetInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhLong(LeaderId);
            writer.WriteVarUhShort(NbMembers);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            LeaderId = reader.ReadVarUhLong();
            NbMembers = reader.ReadVarUhShort();
        }

    }
}
