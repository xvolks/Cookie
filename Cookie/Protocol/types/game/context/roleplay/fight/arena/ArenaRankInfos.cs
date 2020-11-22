using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class ArenaRankInfos : NetworkType
    {
        public const short ProtocolId = 499;
        public override short TypeId { get { return ProtocolId; } }

        public ArenaRanking Ranking;
        public ArenaLeagueRanking LeagueRanking;
        public short VictoryCount = 0;
        public short Fightcount = 0;
        public short NumFightNeededForLadder = 0;

        public ArenaRankInfos()
        {
        }

        public ArenaRankInfos(
            ArenaRanking ranking,
            ArenaLeagueRanking leagueRanking,
            short victoryCount,
            short fightcount,
            short numFightNeededForLadder
        )
        {
            Ranking = ranking;
            LeagueRanking = leagueRanking;
            VictoryCount = victoryCount;
            Fightcount = fightcount;
            NumFightNeededForLadder = numFightNeededForLadder;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            Ranking.Serialize(writer);
            LeagueRanking.Serialize(writer);
            writer.WriteVarShort(VictoryCount);
            writer.WriteVarShort(Fightcount);
            writer.WriteShort(NumFightNeededForLadder);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Ranking = new ArenaRanking();
            Ranking.Deserialize(reader);
            LeagueRanking = new ArenaLeagueRanking();
            LeagueRanking.Deserialize(reader);
            VictoryCount = reader.ReadVarShort();
            Fightcount = reader.ReadVarShort();
            NumFightNeededForLadder = reader.ReadShort();
        }
    }
}