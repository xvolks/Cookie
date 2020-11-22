using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameRolePlayArenaLeagueRewardsMessage : NetworkMessage
    {
        public const uint ProtocolId = 6785;
        public override uint MessageID { get { return ProtocolId; } }

        public short SeasonId = 0;
        public short LeagueId = 0;
        public int LadderPosition = 0;
        public bool EndSeasonReward = false;

        public GameRolePlayArenaLeagueRewardsMessage()
        {
        }

        public GameRolePlayArenaLeagueRewardsMessage(
            short seasonId,
            short leagueId,
            int ladderPosition,
            bool endSeasonReward
        )
        {
            SeasonId = seasonId;
            LeagueId = leagueId;
            LadderPosition = ladderPosition;
            EndSeasonReward = endSeasonReward;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(SeasonId);
            writer.WriteVarShort(LeagueId);
            writer.WriteInt(LadderPosition);
            writer.WriteBoolean(EndSeasonReward);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            SeasonId = reader.ReadVarShort();
            LeagueId = reader.ReadVarShort();
            LadderPosition = reader.ReadInt();
            EndSeasonReward = reader.ReadBoolean();
        }
    }
}