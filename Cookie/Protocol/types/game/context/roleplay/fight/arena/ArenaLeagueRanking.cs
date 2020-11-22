using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class ArenaLeagueRanking : NetworkType
    {
        public const short ProtocolId = 553;
        public override short TypeId { get { return ProtocolId; } }

        public short Rank = 0;
        public short LeagueId = 0;
        public short LeaguePoints = 0;
        public short TotalLeaguePoints = 0;
        public int LadderPosition = 0;

        public ArenaLeagueRanking()
        {
        }

        public ArenaLeagueRanking(
            short rank,
            short leagueId,
            short leaguePoints,
            short totalLeaguePoints,
            int ladderPosition
        )
        {
            Rank = rank;
            LeagueId = leagueId;
            LeaguePoints = leaguePoints;
            TotalLeaguePoints = totalLeaguePoints;
            LadderPosition = ladderPosition;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(Rank);
            writer.WriteVarShort(LeagueId);
            writer.WriteVarShort(LeaguePoints);
            writer.WriteVarShort(TotalLeaguePoints);
            writer.WriteInt(LadderPosition);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Rank = reader.ReadVarShort();
            LeagueId = reader.ReadVarShort();
            LeaguePoints = reader.ReadVarShort();
            TotalLeaguePoints = reader.ReadVarShort();
            LadderPosition = reader.ReadInt();
        }
    }
}