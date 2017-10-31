namespace Cookie.API.Protocol.Network.Messages.Game.Context.Fight
{
    using Utils.IO;

    public class GameFightRemoveTeamMemberMessage : NetworkMessage
    {
        public const ushort ProtocolId = 711;
        public override ushort MessageID => ProtocolId;
        public short FightId { get; set; }
        public byte TeamId { get; set; }
        public double CharId { get; set; }

        public GameFightRemoveTeamMemberMessage(short fightId, byte teamId, double charId)
        {
            FightId = fightId;
            TeamId = teamId;
            CharId = charId;
        }

        public GameFightRemoveTeamMemberMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(FightId);
            writer.WriteByte(TeamId);
            writer.WriteDouble(CharId);
        }

        public override void Deserialize(IDataReader reader)
        {
            FightId = reader.ReadShort();
            TeamId = reader.ReadByte();
            CharId = reader.ReadDouble();
        }

    }
}
