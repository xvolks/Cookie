using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class FightResultExperienceData : FightResultAdditionalData
    {
        public new const short ProtocolId = 192;
        public override short TypeId { get { return ProtocolId; } }

        public bool ShowExperience = false;
        public bool ShowExperienceLevelFloor = false;
        public bool ShowExperienceNextLevelFloor = false;
        public bool ShowExperienceFightDelta = false;
        public bool ShowExperienceForGuild = false;
        public bool ShowExperienceForMount = false;
        public bool IsIncarnationExperience = false;
        public long Experience = 0;
        public long ExperienceLevelFloor = 0;
        public long ExperienceNextLevelFloor = 0;
        public long ExperienceFightDelta = 0;
        public long ExperienceForGuild = 0;
        public long ExperienceForMount = 0;
        public byte RerollExperienceMul = 0;

        public FightResultExperienceData(): base()
        {
        }

        public FightResultExperienceData(
            bool showExperience,
            bool showExperienceLevelFloor,
            bool showExperienceNextLevelFloor,
            bool showExperienceFightDelta,
            bool showExperienceForGuild,
            bool showExperienceForMount,
            bool isIncarnationExperience,
            long experience,
            long experienceLevelFloor,
            long experienceNextLevelFloor,
            long experienceFightDelta,
            long experienceForGuild,
            long experienceForMount,
            byte rerollExperienceMul
        ): base()
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

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            byte box0 = 0;
            box0 = BooleanByteWrapper.SetFlag(box0, 1, ShowExperience);
            box0 = BooleanByteWrapper.SetFlag(box0, 2, ShowExperienceLevelFloor);
            box0 = BooleanByteWrapper.SetFlag(box0, 3, ShowExperienceNextLevelFloor);
            box0 = BooleanByteWrapper.SetFlag(box0, 4, ShowExperienceFightDelta);
            box0 = BooleanByteWrapper.SetFlag(box0, 5, ShowExperienceForGuild);
            box0 = BooleanByteWrapper.SetFlag(box0, 6, ShowExperienceForMount);
            box0 = BooleanByteWrapper.SetFlag(box0, 7, IsIncarnationExperience);
            writer.WriteByte(box0);
            writer.WriteVarLong(Experience);
            writer.WriteVarLong(ExperienceLevelFloor);
            writer.WriteVarLong(ExperienceNextLevelFloor);
            writer.WriteVarLong(ExperienceFightDelta);
            writer.WriteVarLong(ExperienceForGuild);
            writer.WriteVarLong(ExperienceForMount);
            writer.WriteByte(RerollExperienceMul);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            byte box0 = reader.ReadByte();
            ShowExperience = BooleanByteWrapper.GetFlag(box0, 1);
            ShowExperienceLevelFloor = BooleanByteWrapper.GetFlag(box0, 2);
            ShowExperienceNextLevelFloor = BooleanByteWrapper.GetFlag(box0, 3);
            ShowExperienceFightDelta = BooleanByteWrapper.GetFlag(box0, 4);
            ShowExperienceForGuild = BooleanByteWrapper.GetFlag(box0, 5);
            ShowExperienceForMount = BooleanByteWrapper.GetFlag(box0, 6);
            IsIncarnationExperience = BooleanByteWrapper.GetFlag(box0, 7);
            Experience = reader.ReadVarLong();
            ExperienceLevelFloor = reader.ReadVarLong();
            ExperienceNextLevelFloor = reader.ReadVarLong();
            ExperienceFightDelta = reader.ReadVarLong();
            ExperienceForGuild = reader.ReadVarLong();
            ExperienceForMount = reader.ReadVarLong();
            RerollExperienceMul = reader.ReadByte();
        }
    }
}