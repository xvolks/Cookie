using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameRolePlayArenaLeagueRewardsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6785;

        public override ushort MessageID => ProtocolId;

        public ushort SeasonId { get; set; }
        public ushort LeagueId { get; set; }
        public int LadderPosition { get; set; }
        public bool EndSeasonReward { get; set; }
        public GameRolePlayArenaLeagueRewardsMessage() { }

        public GameRolePlayArenaLeagueRewardsMessage( ushort SeasonId, ushort LeagueId, int LadderPosition, bool EndSeasonReward ){
            this.SeasonId = SeasonId;
            this.LeagueId = LeagueId;
            this.LadderPosition = LadderPosition;
            this.EndSeasonReward = EndSeasonReward;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(SeasonId);
            writer.WriteVarUhShort(LeagueId);
            writer.WriteInt(LadderPosition);
            writer.WriteBoolean(EndSeasonReward);
        }

        public override void Deserialize(IDataReader reader)
        {
            SeasonId = reader.ReadVarUhShort();
            LeagueId = reader.ReadVarUhShort();
            LadderPosition = reader.ReadInt();
            EndSeasonReward = reader.ReadBoolean();
        }
    }
}
