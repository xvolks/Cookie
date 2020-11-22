using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class FriendInformations : AbstractContactInformations
    {
        public new const short ProtocolId = 78;
        public override short TypeId { get { return ProtocolId; } }

        public byte PlayerState = 99;
        public short LastConnection = 0;
        public int AchievementPoints = 0;
        public short LeagueId = 0;
        public int LadderPosition = 0;

        public FriendInformations(): base()
        {
        }

        public FriendInformations(
            int accountId,
            string accountName,
            byte playerState,
            short lastConnection,
            int achievementPoints,
            short leagueId,
            int ladderPosition
        ): base(
            accountId,
            accountName
        )
        {
            PlayerState = playerState;
            LastConnection = lastConnection;
            AchievementPoints = achievementPoints;
            LeagueId = leagueId;
            LadderPosition = ladderPosition;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteByte(PlayerState);
            writer.WriteVarShort(LastConnection);
            writer.WriteInt(AchievementPoints);
            writer.WriteVarShort(LeagueId);
            writer.WriteInt(LadderPosition);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            PlayerState = reader.ReadByte();
            LastConnection = reader.ReadVarShort();
            AchievementPoints = reader.ReadInt();
            LeagueId = reader.ReadVarShort();
            LadderPosition = reader.ReadInt();
        }
    }
}