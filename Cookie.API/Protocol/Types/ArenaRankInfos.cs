using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class ArenaRankInfos : NetworkType
    {
        public const ushort ProtocolId = 499;

        public override ushort TypeID => ProtocolId;

        public ArenaRanking Ranking { get; set; }
        public ArenaLeagueRanking LeagueRanking { get; set; }
        public ushort VictoryCount { get; set; }
        public ushort Fightcount { get; set; }
        public short NumFightNeededForLadder { get; set; }
        public ArenaRankInfos() { }

        public ArenaRankInfos( ArenaRanking Ranking, ArenaLeagueRanking LeagueRanking, ushort VictoryCount, ushort Fightcount, short NumFightNeededForLadder ){
            this.Ranking = Ranking;
            this.LeagueRanking = LeagueRanking;
            this.VictoryCount = VictoryCount;
            this.Fightcount = Fightcount;
            this.NumFightNeededForLadder = NumFightNeededForLadder;
        }

        public override void Serialize(IDataWriter writer)
        {
            Ranking.Serialize(writer);
            LeagueRanking.Serialize(writer);
            writer.WriteVarUhShort(VictoryCount);
            writer.WriteVarUhShort(Fightcount);
            writer.WriteShort(NumFightNeededForLadder);
        }

        public override void Deserialize(IDataReader reader)
        {
            Ranking = new ArenaRanking();
            Ranking.Deserialize(reader);
            LeagueRanking = new ArenaLeagueRanking();
            LeagueRanking.Deserialize(reader);
            VictoryCount = reader.ReadVarUhShort();
            Fightcount = reader.ReadVarUhShort();
            NumFightNeededForLadder = reader.ReadShort();
        }
    }
}
