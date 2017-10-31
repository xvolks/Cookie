namespace Cookie.API.Protocol.Network.Messages.Game.Guild.Tax
{
    using Utils.IO;

    public class GuildFightPlayersEnemyRemoveMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5929;
        public override ushort MessageID => ProtocolId;
        public double FightId { get; set; }
        public ulong PlayerId { get; set; }

        public GuildFightPlayersEnemyRemoveMessage(double fightId, ulong playerId)
        {
            FightId = fightId;
            PlayerId = playerId;
        }

        public GuildFightPlayersEnemyRemoveMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(FightId);
            writer.WriteVarUhLong(PlayerId);
        }

        public override void Deserialize(IDataReader reader)
        {
            FightId = reader.ReadDouble();
            PlayerId = reader.ReadVarUhLong();
        }

    }
}
