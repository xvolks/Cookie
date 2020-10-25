using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class RefreshCharacterStatsMessage : NetworkMessage
    {
        public const uint ProtocolId = 6699;
        public override uint MessageID { get { return ProtocolId; } }

        public double FighterId = 0;
        public GameFightMinimalStats Stats;

        public RefreshCharacterStatsMessage()
        {
        }

        public RefreshCharacterStatsMessage(
            double fighterId,
            GameFightMinimalStats stats
        )
        {
            FighterId = fighterId;
            Stats = stats;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(FighterId);
            Stats.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            FighterId = reader.ReadDouble();
            Stats = new GameFightMinimalStats();
            Stats.Deserialize(reader);
        }
    }
}