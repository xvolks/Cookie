using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class FriendOnlineInformations : FriendInformations
    {
        public new const short ProtocolId = 92;
        public override short TypeId { get { return ProtocolId; } }

        public bool Sex = false;
        public bool HavenBagShared = false;
        public long PlayerId = 0;
        public string PlayerName;
        public short Level = 0;
        public byte AlignmentSide = 0;
        public byte Breed = 0;
        public GuildInformations GuildInfo;
        public short MoodSmileyId = 0;
        public PlayerStatus Status;

        public FriendOnlineInformations(): base()
        {
        }

        public FriendOnlineInformations(
            int accountId,
            string accountName,
            byte playerState,
            short lastConnection,
            int achievementPoints,
            short leagueId,
            int ladderPosition,
            bool sex,
            bool havenBagShared,
            long playerId,
            string playerName,
            short level,
            byte alignmentSide,
            byte breed,
            GuildInformations guildInfo,
            short moodSmileyId,
            PlayerStatus status
        ): base(
            accountId,
            accountName,
            playerState,
            lastConnection,
            achievementPoints,
            leagueId,
            ladderPosition
        )
        {
            Sex = sex;
            HavenBagShared = havenBagShared;
            PlayerId = playerId;
            PlayerName = playerName;
            Level = level;
            AlignmentSide = alignmentSide;
            Breed = breed;
            GuildInfo = guildInfo;
            MoodSmileyId = moodSmileyId;
            Status = status;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            byte box0 = 0;
            box0 = BooleanByteWrapper.SetFlag(box0, 1, Sex);
            box0 = BooleanByteWrapper.SetFlag(box0, 2, HavenBagShared);
            writer.WriteByte(box0);
            writer.WriteVarLong(PlayerId);
            writer.WriteUTF(PlayerName);
            writer.WriteVarShort(Level);
            writer.WriteByte(AlignmentSide);
            writer.WriteByte(Breed);
            GuildInfo.Serialize(writer);
            writer.WriteVarShort(MoodSmileyId);
            writer.WriteShort(Status.TypeId);
            Status.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            byte box0 = reader.ReadByte();
            Sex = BooleanByteWrapper.GetFlag(box0, 1);
            HavenBagShared = BooleanByteWrapper.GetFlag(box0, 2);
            PlayerId = reader.ReadVarLong();
            PlayerName = reader.ReadUTF();
            Level = reader.ReadVarShort();
            AlignmentSide = reader.ReadByte();
            Breed = reader.ReadByte();
            GuildInfo = new GuildInformations();
            GuildInfo.Deserialize(reader);
            MoodSmileyId = reader.ReadVarShort();
            var statusTypeId = reader.ReadShort();
            Status = new PlayerStatus();
            Status.Deserialize(reader);
        }
    }
}