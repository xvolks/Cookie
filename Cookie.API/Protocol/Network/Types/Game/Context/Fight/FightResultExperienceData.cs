//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cookie.API.Protocol.Network.Types.Game.Context.Fight
{
    using System.Collections.Generic;
    using Cookie.API.Protocol.Network.Messages;
    using Cookie.API.Protocol.Network.Types;
    using Cookie.API.Utils.IO;
    
    
    public class FightResultExperienceData : FightResultAdditionalData
    {
        
        public new const short ProtocolId = 192;
        
        public override short TypeID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private bool m_showExperience;
        
        public virtual bool ShowExperience
        {
            get
            {
                return m_showExperience;
            }
            set
            {
                m_showExperience = value;
            }
        }
        
        private bool m_showExperienceLevelFloor;
        
        public virtual bool ShowExperienceLevelFloor
        {
            get
            {
                return m_showExperienceLevelFloor;
            }
            set
            {
                m_showExperienceLevelFloor = value;
            }
        }
        
        private bool m_showExperienceNextLevelFloor;
        
        public virtual bool ShowExperienceNextLevelFloor
        {
            get
            {
                return m_showExperienceNextLevelFloor;
            }
            set
            {
                m_showExperienceNextLevelFloor = value;
            }
        }
        
        private bool m_showExperienceFightDelta;
        
        public virtual bool ShowExperienceFightDelta
        {
            get
            {
                return m_showExperienceFightDelta;
            }
            set
            {
                m_showExperienceFightDelta = value;
            }
        }
        
        private bool m_showExperienceForGuild;
        
        public virtual bool ShowExperienceForGuild
        {
            get
            {
                return m_showExperienceForGuild;
            }
            set
            {
                m_showExperienceForGuild = value;
            }
        }
        
        private bool m_showExperienceForMount;
        
        public virtual bool ShowExperienceForMount
        {
            get
            {
                return m_showExperienceForMount;
            }
            set
            {
                m_showExperienceForMount = value;
            }
        }
        
        private bool m_isIncarnationExperience;
        
        public virtual bool IsIncarnationExperience
        {
            get
            {
                return m_isIncarnationExperience;
            }
            set
            {
                m_isIncarnationExperience = value;
            }
        }
        
        private ulong m_experience;
        
        public virtual ulong Experience
        {
            get
            {
                return m_experience;
            }
            set
            {
                m_experience = value;
            }
        }
        
        private ulong m_experienceLevelFloor;
        
        public virtual ulong ExperienceLevelFloor
        {
            get
            {
                return m_experienceLevelFloor;
            }
            set
            {
                m_experienceLevelFloor = value;
            }
        }
        
        private ulong m_experienceNextLevelFloor;
        
        public virtual ulong ExperienceNextLevelFloor
        {
            get
            {
                return m_experienceNextLevelFloor;
            }
            set
            {
                m_experienceNextLevelFloor = value;
            }
        }
        
        private ulong m_experienceFightDelta;
        
        public virtual ulong ExperienceFightDelta
        {
            get
            {
                return m_experienceFightDelta;
            }
            set
            {
                m_experienceFightDelta = value;
            }
        }
        
        private ulong m_experienceForGuild;
        
        public virtual ulong ExperienceForGuild
        {
            get
            {
                return m_experienceForGuild;
            }
            set
            {
                m_experienceForGuild = value;
            }
        }
        
        private ulong m_experienceForMount;
        
        public virtual ulong ExperienceForMount
        {
            get
            {
                return m_experienceForMount;
            }
            set
            {
                m_experienceForMount = value;
            }
        }
        
        private byte m_rerollExperienceMul;
        
        public virtual byte RerollExperienceMul
        {
            get
            {
                return m_rerollExperienceMul;
            }
            set
            {
                m_rerollExperienceMul = value;
            }
        }
        
        public FightResultExperienceData(bool showExperience, bool showExperienceLevelFloor, bool showExperienceNextLevelFloor, bool showExperienceFightDelta, bool showExperienceForGuild, bool showExperienceForMount, bool isIncarnationExperience, ulong experience, ulong experienceLevelFloor, ulong experienceNextLevelFloor, ulong experienceFightDelta, ulong experienceForGuild, ulong experienceForMount, byte rerollExperienceMul)
        {
            m_showExperience = showExperience;
            m_showExperienceLevelFloor = showExperienceLevelFloor;
            m_showExperienceNextLevelFloor = showExperienceNextLevelFloor;
            m_showExperienceFightDelta = showExperienceFightDelta;
            m_showExperienceForGuild = showExperienceForGuild;
            m_showExperienceForMount = showExperienceForMount;
            m_isIncarnationExperience = isIncarnationExperience;
            m_experience = experience;
            m_experienceLevelFloor = experienceLevelFloor;
            m_experienceNextLevelFloor = experienceNextLevelFloor;
            m_experienceFightDelta = experienceFightDelta;
            m_experienceForGuild = experienceForGuild;
            m_experienceForMount = experienceForMount;
            m_rerollExperienceMul = rerollExperienceMul;
        }
        
        public FightResultExperienceData()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            byte flag = new byte();
            BooleanByteWrapper.SetFlag(0, flag, m_showExperience);
            BooleanByteWrapper.SetFlag(1, flag, m_showExperienceLevelFloor);
            BooleanByteWrapper.SetFlag(2, flag, m_showExperienceNextLevelFloor);
            BooleanByteWrapper.SetFlag(3, flag, m_showExperienceFightDelta);
            BooleanByteWrapper.SetFlag(4, flag, m_showExperienceForGuild);
            BooleanByteWrapper.SetFlag(5, flag, m_showExperienceForMount);
            BooleanByteWrapper.SetFlag(6, flag, m_isIncarnationExperience);
            writer.WriteByte(flag);
            writer.WriteVarUhLong(m_experience);
            writer.WriteVarUhLong(m_experienceLevelFloor);
            writer.WriteVarUhLong(m_experienceNextLevelFloor);
            writer.WriteVarUhLong(m_experienceFightDelta);
            writer.WriteVarUhLong(m_experienceForGuild);
            writer.WriteVarUhLong(m_experienceForMount);
            writer.WriteByte(m_rerollExperienceMul);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            byte flag = reader.ReadByte();
            m_showExperience = BooleanByteWrapper.GetFlag(flag, 0);
            m_showExperienceLevelFloor = BooleanByteWrapper.GetFlag(flag, 1);
            m_showExperienceNextLevelFloor = BooleanByteWrapper.GetFlag(flag, 2);
            m_showExperienceFightDelta = BooleanByteWrapper.GetFlag(flag, 3);
            m_showExperienceForGuild = BooleanByteWrapper.GetFlag(flag, 4);
            m_showExperienceForMount = BooleanByteWrapper.GetFlag(flag, 5);
            m_isIncarnationExperience = BooleanByteWrapper.GetFlag(flag, 6);
            m_experience = reader.ReadVarUhLong();
            m_experienceLevelFloor = reader.ReadVarUhLong();
            m_experienceNextLevelFloor = reader.ReadVarUhLong();
            m_experienceFightDelta = reader.ReadVarUhLong();
            m_experienceForGuild = reader.ReadVarUhLong();
            m_experienceForMount = reader.ReadVarUhLong();
            m_rerollExperienceMul = reader.ReadByte();
        }
    }
}
