using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildFightPlayersEnemyRemoveMessage : NetworkMessage
    {
        public const uint ProtocolId = 5929;
        public override uint MessageID { get { return ProtocolId; } }

        public double FightId = 0;
        public long PlayerId = 0;

        public GuildFightPlayersEnemyRemoveMessage()
        {
        }

        public GuildFightPlayersEnemyRemoveMessage(
            double fightId,
            long playerId
        )
        {
            FightId = fightId;
            PlayerId = playerId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(FightId);
            writer.WriteVarLong(PlayerId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            FightId = reader.ReadDouble();
            PlayerId = reader.ReadVarLong();
        }
    }
}