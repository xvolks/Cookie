using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class ArenaLeagueRanking : NetworkType
    {
        public const ushort ProtocolId = 553;

        public override ushort TypeID => ProtocolId;

        public ushort Rank { get; set; }
        public ushort LeagueId { get; set; }
        public short LeaguePoints { get; set; }
        public short TotalLeaguePoints { get; set; }
        public int LadderPosition { get; set; }
        public ArenaLeagueRanking() { }

        public ArenaLeagueRanking( ushort Rank, ushort LeagueId, short LeaguePoints, short TotalLeaguePoints, int LadderPosition ){
            this.Rank = Rank;
            this.LeagueId = LeagueId;
            this.LeaguePoints = LeaguePoints;
            this.TotalLeaguePoints = TotalLeaguePoints;
            this.LadderPosition = LadderPosition;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(Rank);
            writer.WriteVarUhShort(LeagueId);
            writer.WriteVarShort(LeaguePoints);
            writer.WriteVarShort(TotalLeaguePoints);
            writer.WriteInt(LadderPosition);
        }

        public override void Deserialize(IDataReader reader)
        {
            Rank = reader.ReadVarUhShort();
            LeagueId = reader.ReadVarUhShort();
            LeaguePoints = reader.ReadVarShort();
            TotalLeaguePoints = reader.ReadVarShort();
            LadderPosition = reader.ReadInt();
        }
    }
}
