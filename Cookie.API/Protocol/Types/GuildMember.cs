using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class GuildMember : CharacterMinimalInformations
    {
        public new const ushort ProtocolId = 88;

        public override ushort TypeID => ProtocolId;

        public bool Sex { get; set; }
        public bool HavenBagShared { get; set; }
        public sbyte Breed { get; set; }
        public ushort Rank { get; set; }
        public ulong GivenExperience { get; set; }
        public sbyte ExperienceGivenPercent { get; set; }
        public uint Rights { get; set; }
        public sbyte Connected { get; set; }
        public sbyte AlignmentSide { get; set; }
        public ushort HoursSinceLastConnection { get; set; }
        public ushort MoodSmileyId { get; set; }
        public int AccountId { get; set; }
        public int AchievementPoints { get; set; }
        public PlayerStatus Status { get; set; }
        public GuildMember() { }

        public GuildMember( bool Sex, bool HavenBagShared, sbyte Breed, ushort Rank, ulong GivenExperience, sbyte ExperienceGivenPercent, uint Rights, sbyte Connected, sbyte AlignmentSide, ushort HoursSinceLastConnection, ushort MoodSmileyId, int AccountId, int AchievementPoints, PlayerStatus Status ){
            this.Sex = Sex;
            this.HavenBagShared = HavenBagShared;
            this.Breed = Breed;
            this.Rank = Rank;
            this.GivenExperience = GivenExperience;
            this.ExperienceGivenPercent = ExperienceGivenPercent;
            this.Rights = Rights;
            this.Connected = Connected;
            this.AlignmentSide = AlignmentSide;
            this.HoursSinceLastConnection = HoursSinceLastConnection;
            this.MoodSmileyId = MoodSmileyId;
            this.AccountId = AccountId;
            this.AchievementPoints = AchievementPoints;
            this.Status = Status;
        }

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
            writer.WriteSByte(ExperienceGivenPercent);
            writer.WriteVarUhInt(Rights);
            writer.WriteSByte(Connected);
            writer.WriteSByte(AlignmentSide);
            writer.WriteUnsignedShort(HoursSinceLastConnection);
            writer.WriteVarUhShort(MoodSmileyId);
            writer.WriteInt(AccountId);
            writer.WriteInt(AchievementPoints);
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
            ExperienceGivenPercent = reader.ReadSByte();
            Rights = reader.ReadVarUhInt();
            Connected = reader.ReadSByte();
            AlignmentSide = reader.ReadSByte();
            HoursSinceLastConnection = reader.ReadUnsignedShort();
            MoodSmileyId = reader.ReadVarUhShort();
            AccountId = reader.ReadInt();
            AchievementPoints = reader.ReadInt();
            Status = ProtocolTypeManager.GetInstance(reader.ReadUShort());
            Status.Deserialize(reader);
        }
    }
}
