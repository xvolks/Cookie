using Cookie.API.Protocol.Network.Types.Game.Context.Fight;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Fight
{
    public class RefreshCharacterStatsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6699;

        public RefreshCharacterStatsMessage(double fighterId, GameFightMinimalStats stats)
        {
            FighterId = fighterId;
            Stats = stats;
        }

        public RefreshCharacterStatsMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public double FighterId { get; set; }
        public GameFightMinimalStats Stats { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(FighterId);
            Stats.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            FighterId = reader.ReadDouble();
            Stats = new GameFightMinimalStats();
            Stats.Deserialize(reader);
        }
    }
}