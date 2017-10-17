using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Guild.Tax
{
    public class GuildFightPlayersEnemyRemoveMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5929;

        public GuildFightPlayersEnemyRemoveMessage(double fightId, ulong playerId)
        {
            FightId = fightId;
            PlayerId = playerId;
        }

        public GuildFightPlayersEnemyRemoveMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public double FightId { get; set; }
        public ulong PlayerId { get; set; }

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