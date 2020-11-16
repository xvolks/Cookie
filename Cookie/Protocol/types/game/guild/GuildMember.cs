using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class GuildMember : CharacterMinimalInformations
    {
        public new const short ProtocolId = 88;
        public override short TypeId { get { return ProtocolId; } }

        public bool Sex = false;
        public bool HavenBagShared = false;
        public byte Breed = 0;
        public short Rank = 0;
        public long GivenExperience = 0;
        public byte ExperienceGivenPercent = 0;
        public int Rights = 0;
        public byte Connected = 99;
        public byte AlignmentSide = 0;
        public short HoursSinceLastConnection = 0;
        public short MoodSmileyId = 0;
        public int AccountId = 0;
        public int AchievementPoints = 0;
        public PlayerStatus Status;

        public GuildMember(): base()
        {
        }

        public GuildMember(
            long id_,
            string name,
            short level,
            bool sex,
            bool havenBagShared,
            byte breed,
            short rank,
            long givenExperience,
            byte experienceGivenPercent,
            int rights,
            byte connected,
            byte alignmentSide,
            short hoursSinceLastConnection,
            short moodSmileyId,
            int accountId,
            int achievementPoints,
            PlayerStatus status
        ): base(
            id_,
            name,
            level
        )
        {
            Sex = sex;
            HavenBagShared = havenBagShared;
            Breed = breed;
            Rank = rank;
            GivenExperience = givenExperience;
            ExperienceGivenPercent = experienceGivenPercent;
            Rights = rights;
            Connected = connected;
            AlignmentSide = alignmentSide;
            HoursSinceLastConnection = hoursSinceLastConnection;
            MoodSmileyId = moodSmileyId;
            AccountId = accountId;
            AchievementPoints = achievementPoints;
            Status = status;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            byte box0 = 0;
            box0 = BooleanByteWrapper.SetFlag(box0, 1, Sex);
            box0 = BooleanByteWrapper.SetFlag(box0, 2, HavenBagShared);
            writer.WriteByte(box0);
            writer.WriteByte(Breed);
            writer.WriteVarShort(Rank);
            writer.WriteVarLong(GivenExperience);
            writer.WriteByte(ExperienceGivenPercent);
            writer.WriteVarInt(Rights);
            writer.WriteByte(Connected);
            writer.WriteByte(AlignmentSide);
            writer.WriteShort(HoursSinceLastConnection);
            writer.WriteVarShort(MoodSmileyId);
            writer.WriteInt(AccountId);
            writer.WriteInt(AchievementPoints);
            writer.WriteShort(Status.TypeId);
            Status.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            byte box0 = reader.ReadByte();
            Sex = BooleanByteWrapper.GetFlag(box0, 1);
            HavenBagShared = BooleanByteWrapper.GetFlag(box0, 2);
            Breed = reader.ReadByte();
            Rank = reader.ReadVarShort();
            GivenExperience = reader.ReadVarLong();
            ExperienceGivenPercent = reader.ReadByte();
            Rights = reader.ReadVarInt();
            Connected = reader.ReadByte();
            AlignmentSide = reader.ReadByte();
            HoursSinceLastConnection = reader.ReadShort();
            MoodSmileyId = reader.ReadVarShort();
            AccountId = reader.ReadInt();
            AchievementPoints = reader.ReadInt();
            var statusTypeId = reader.ReadShort();
            Status = new PlayerStatus();
            Status.Deserialize(reader);
        }
    }
}