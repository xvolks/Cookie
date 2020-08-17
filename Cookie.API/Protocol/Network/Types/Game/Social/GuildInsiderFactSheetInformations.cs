using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Social
{
    public class GuildInsiderFactSheetInformations : GuildFactSheetInformations
    {
        public new const ushort ProtocolId = 423;

        public GuildInsiderFactSheetInformations(string leaderName, ushort nbConnectedMembers, byte nbTaxCollectors,
            int lastActivity)
        {
            LeaderName = leaderName;
            NbConnectedMembers = nbConnectedMembers;
            NbTaxCollectors = nbTaxCollectors;
            LastActivity = lastActivity;
        }

        public GuildInsiderFactSheetInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public string LeaderName { get; set; }
        public ushort NbConnectedMembers { get; set; }
        public byte NbTaxCollectors { get; set; }
        public int LastActivity { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(LeaderName);
            writer.WriteVarUhShort(NbConnectedMembers);
            writer.WriteByte(NbTaxCollectors);
            writer.WriteInt(LastActivity);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            LeaderName = reader.ReadUTF();
            NbConnectedMembers = reader.ReadVarUhShort();
            NbTaxCollectors = reader.ReadByte();
            LastActivity = reader.ReadInt();
        }
    }
}