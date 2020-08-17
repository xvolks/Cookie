using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Fight
{
    public class FightResultExperienceData : FightResultAdditionalData
    {
        public new const ushort ProtocolId = 192;

        public FightResultExperienceData(bool showExperience, bool showExperienceLevelFloor,
            bool showExperienceNextLevelFloor, bool showExperienceFightDelta, bool showExperienceForGuild,
            bool showExperienceForMount, bool isIncarnationExperience, ulong experience, ulong experienceLevelFloor,
            ulong experienceNextLevelFloor, ulong experienceFightDelta, ulong experienceForGuild,
            ulong experienceForMount, byte rerollExperienceMul)
        {
            ShowExperience = showExperience;
            ShowExperienceLevelFloor = showExperienceLevelFloor;
            ShowExperienceNextLevelFloor = showExperienceNextLevelFloor;
            ShowExperienceFightDelta = showExperienceFightDelta;
            ShowExperienceForGuild = showExperienceForGuild;
            ShowExperienceForMount = showExperienceForMount;
            IsIncarnationExperience = isIncarnationExperience;
            Experience = experience;
            ExperienceLevelFloor = experienceLevelFloor;
            ExperienceNextLevelFloor = experienceNextLevelFloor;
            ExperienceFightDelta = experienceFightDelta;
            ExperienceForGuild = experienceForGuild;
            ExperienceForMount = experienceForMount;
            RerollExperienceMul = rerollExperienceMul;
        }

        public FightResultExperienceData()
        {
        }

        public override ushort TypeID => ProtocolId;
        public bool ShowExperience { get; set; }
        public bool ShowExperienceLevelFloor { get; set; }
        public bool ShowExperienceNextLevelFloor { get; set; }
        public bool ShowExperienceFightDelta { get; set; }
        public bool ShowExperienceForGuild { get; set; }
        public bool ShowExperienceForMount { get; set; }
        public bool IsIncarnationExperience { get; set; }
        public ulong Experience { get; set; }
        public ulong ExperienceLevelFloor { get; set; }
        public ulong ExperienceNextLevelFloor { get; set; }
        public ulong ExperienceFightDelta { get; set; }
        public ulong ExperienceForGuild { get; set; }
        public ulong ExperienceForMount { get; set; }
        public byte RerollExperienceMul { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            var flag = new byte();
            flag = BooleanByteWrapper.SetFlag(0, flag, ShowExperience);
            flag = BooleanByteWrapper.SetFlag(1, flag, ShowExperienceLevelFloor);
            flag = BooleanByteWrapper.SetFlag(2, flag, ShowExperienceNextLevelFloor);
            flag = BooleanByteWrapper.SetFlag(3, flag, ShowExperienceFightDelta);
            flag = BooleanByteWrapper.SetFlag(4, flag, ShowExperienceForGuild);
            flag = BooleanByteWrapper.SetFlag(5, flag, ShowExperienceForMount);
            flag = BooleanByteWrapper.SetFlag(6, flag, IsIncarnationExperience);
            writer.WriteByte(flag);
            writer.WriteVarUhLong(Experience);
            writer.WriteVarUhLong(ExperienceLevelFloor);
            writer.WriteVarUhLong(ExperienceNextLevelFloor);
            writer.WriteVarUhLong(ExperienceFightDelta);
            writer.WriteVarUhLong(ExperienceForGuild);
            writer.WriteVarUhLong(ExperienceForMount);
            writer.WriteByte(RerollExperienceMul);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var flag = reader.ReadByte();
            ShowExperience = BooleanByteWrapper.GetFlag(flag, 0);
            ShowExperienceLevelFloor = BooleanByteWrapper.GetFlag(flag, 1);
            ShowExperienceNextLevelFloor = BooleanByteWrapper.GetFlag(flag, 2);
            ShowExperienceFightDelta = BooleanByteWrapper.GetFlag(flag, 3);
            ShowExperienceForGuild = BooleanByteWrapper.GetFlag(flag, 4);
            ShowExperienceForMount = BooleanByteWrapper.GetFlag(flag, 5);
            IsIncarnationExperience = BooleanByteWrapper.GetFlag(flag, 6);
            Experience = reader.ReadVarUhLong();
            ExperienceLevelFloor = reader.ReadVarUhLong();
            ExperienceNextLevelFloor = reader.ReadVarUhLong();
            ExperienceFightDelta = reader.ReadVarUhLong();
            ExperienceForGuild = reader.ReadVarUhLong();
            ExperienceForMount = reader.ReadVarUhLong();
            RerollExperienceMul = reader.ReadByte();
        }
    }
}