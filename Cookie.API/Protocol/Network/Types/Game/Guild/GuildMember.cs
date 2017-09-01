using Cookie.API.Protocol.Network.Types.Game.Character;
using Cookie.API.Protocol.Network.Types.Game.Character.Status;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Guild
{
    public class GuildMember : CharacterMinimalInformations
    {
        public new const ushort ProtocolId = 88;

        public GuildMember(bool sex, bool havenBagShared, sbyte breed, ushort rank, ulong givenExperience,
            byte experienceGivenPercent, uint rights, byte connected, sbyte alignmentSide,
            ushort hoursSinceLastConnection, ushort moodSmileyId, int accountId, int achievementPoints,
            PlayerStatus status)
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

        public GuildMember()
        {
        }

        public override ushort TypeID => ProtocolId;
        public bool Sex { get; set; }
        public bool HavenBagShared { get; set; }
        public sbyte Breed { get; set; }
        public ushort Rank { get; set; }
        public ulong GivenExperience { get; set; }
        public byte ExperienceGivenPercent { get; set; }
        public uint Rights { get; set; }
        public byte Connected { get; set; }
        public sbyte AlignmentSide { get; set; }
        public ushort HoursSinceLastConnection { get; set; }
        public ushort MoodSmileyId { get; set; }
        public int AccountId { get; set; }
        public int AchievementPoints { get; set; }
        public PlayerStatus Status { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            var flag = new byte();
            flag = BooleanByteWrapper.SetFlag(0, flag, Sex);
            flag = BooleanByteWrapper.SetFlag(1, flag, HavenBagShared);
            writer.WriteByte(flag);
            writer.WriteSByte(Breed);
            writer.WriteVarUhShort(Rank);
            writer.WriteVarUhLong(GivenExperience);
            writer.WriteByte(ExperienceGivenPercent);
            writer.WriteVarUhInt(Rights);
            writer.WriteByte(Connected);
            writer.WriteSByte(AlignmentSide);
            writer.WriteUShort(HoursSinceLastConnection);
            writer.WriteVarUhShort(MoodSmileyId);
            writer.WriteInt(AccountId);
            writer.WriteInt(AchievementPoints);
            writer.WriteUShort(Status.TypeID);
            Status.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var flag = reader.ReadByte();
            Sex = BooleanByteWrapper.GetFlag(flag, 0);
            HavenBagShared = BooleanByteWrapper.GetFlag(flag, 1);
            Breed = reader.ReadSByte();
            Rank = reader.ReadVarUhShort();
            GivenExperience = reader.ReadVarUhLong();
            ExperienceGivenPercent = reader.ReadByte();
            Rights = reader.ReadVarUhInt();
            Connected = reader.ReadByte();
            AlignmentSide = reader.ReadSByte();
            HoursSinceLastConnection = reader.ReadUShort();
            MoodSmileyId = reader.ReadVarUhShort();
            AccountId = reader.ReadInt();
            AchievementPoints = reader.ReadInt();
            Status = ProtocolTypeManager.GetInstance<PlayerStatus>(reader.ReadUShort());
            Status.Deserialize(reader);
        }
    }
}