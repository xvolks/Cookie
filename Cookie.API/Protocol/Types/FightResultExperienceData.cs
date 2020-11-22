using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class FightResultExperienceData : FightResultAdditionalData
    {
        public new const ushort ProtocolId = 192;

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
        public sbyte RerollExperienceMul { get; set; }
        public FightResultExperienceData() { }

        public FightResultExperienceData( bool ShowExperience, bool ShowExperienceLevelFloor, bool ShowExperienceNextLevelFloor, bool ShowExperienceFightDelta, bool ShowExperienceForGuild, bool ShowExperienceForMount, bool IsIncarnationExperience, ulong Experience, ulong ExperienceLevelFloor, ulong ExperienceNextLevelFloor, ulong ExperienceFightDelta, ulong ExperienceForGuild, ulong ExperienceForMount, sbyte RerollExperienceMul ){
            this.ShowExperience = ShowExperience;
            this.ShowExperienceLevelFloor = ShowExperienceLevelFloor;
            this.ShowExperienceNextLevelFloor = ShowExperienceNextLevelFloor;
            this.ShowExperienceFightDelta = ShowExperienceFightDelta;
            this.ShowExperienceForGuild = ShowExperienceForGuild;
            this.ShowExperienceForMount = ShowExperienceForMount;
            this.IsIncarnationExperience = IsIncarnationExperience;
            this.Experience = Experience;
            this.ExperienceLevelFloor = ExperienceLevelFloor;
            this.ExperienceNextLevelFloor = ExperienceNextLevelFloor;
            this.ExperienceFightDelta = ExperienceFightDelta;
            this.ExperienceForGuild = ExperienceForGuild;
            this.ExperienceForMount = ExperienceForMount;
            this.RerollExperienceMul = RerollExperienceMul;
        }

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
            writer.WriteSByte(RerollExperienceMul);
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
            RerollExperienceMul = reader.ReadSByte();
        }
    }
}
