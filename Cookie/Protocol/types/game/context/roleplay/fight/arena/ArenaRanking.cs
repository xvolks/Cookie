using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class ArenaRanking : NetworkType
    {
        public const short ProtocolId = 554;
        public override short TypeId { get { return ProtocolId; } }

        public short Rank = 0;
        public short BestRank = 0;

        public ArenaRanking()
        {
        }

        public ArenaRanking(
            short rank,
            short bestRank
        )
        {
            Rank = rank;
            BestRank = bestRank;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(Rank);
            writer.WriteVarShort(BestRank);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Rank = reader.ReadVarShort();
            BestRank = reader.ReadVarShort();
        }
    }
}