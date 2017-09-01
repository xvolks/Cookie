namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.Party
{
    using Utils.IO;

    public class NamedPartyTeamWithOutcome : NetworkType
    {
        public const ushort ProtocolId = 470;
        public override ushort TypeID => ProtocolId;
        public NamedPartyTeam Team { get; set; }
        public ushort Outcome { get; set; }

        public NamedPartyTeamWithOutcome(NamedPartyTeam team, ushort outcome)
        {
            Team = team;
            Outcome = outcome;
        }

        public NamedPartyTeamWithOutcome() { }

        public override void Serialize(IDataWriter writer)
        {
            Team.Serialize(writer);
            writer.WriteVarUhShort(Outcome);
        }

        public override void Deserialize(IDataReader reader)
        {
            Team = new NamedPartyTeam();
            Team.Deserialize(reader);
            Outcome = reader.ReadVarUhShort();
        }

    }
}
