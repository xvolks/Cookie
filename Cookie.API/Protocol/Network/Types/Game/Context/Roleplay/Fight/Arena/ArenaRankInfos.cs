using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.Fight.Arena
{
    public class ArenaRankInfos : NetworkType
    {
        public const ushort ProtocolId = 499;

        public ArenaRankInfos(ushort rank, ushort bestRank, ushort victoryCount, ushort fightcount)
        {
            Rank = rank;
            BestRank = bestRank;
            VictoryCount = victoryCount;
            Fightcount = fightcount;
        }

        public ArenaRankInfos()
        {
        }

        public override ushort TypeID => ProtocolId;
        public ushort Rank { get; set; }
        public ushort BestRank { get; set; }
        public ushort VictoryCount { get; set; }
        public ushort Fightcount { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(Rank);
            writer.WriteVarUhShort(BestRank);
            writer.WriteVarUhShort(VictoryCount);
            writer.WriteVarUhShort(Fightcount);
        }

        public override void Deserialize(IDataReader reader)
        {
            Rank = reader.ReadVarUhShort();
            BestRank = reader.ReadVarUhShort();
            VictoryCount = reader.ReadVarUhShort();
            Fightcount = reader.ReadVarUhShort();
        }
    }
}