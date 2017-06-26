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
    using Cookie.API.Utils.IO;


    public class FightTeamLightInformations : AbstractFightTeamInformations
    {
        
        public new const short ProtocolId = 115;
        
        public override short TypeID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private bool m_hasFriend;
        
        public virtual bool HasFriend
        {
            get
            {
                return m_hasFriend;
            }
            set
            {
                m_hasFriend = value;
            }
        }
        
        private bool m_hasGuildMember;
        
        public virtual bool HasGuildMember
        {
            get
            {
                return m_hasGuildMember;
            }
            set
            {
                m_hasGuildMember = value;
            }
        }
        
        private bool m_hasAllianceMember;
        
        public virtual bool HasAllianceMember
        {
            get
            {
                return m_hasAllianceMember;
            }
            set
            {
                m_hasAllianceMember = value;
            }
        }
        
        private bool m_hasGroupMember;
        
        public virtual bool HasGroupMember
        {
            get
            {
                return m_hasGroupMember;
            }
            set
            {
                m_hasGroupMember = value;
            }
        }
        
        private bool m_hasMyTaxCollector;
        
        public virtual bool HasMyTaxCollector
        {
            get
            {
                return m_hasMyTaxCollector;
            }
            set
            {
                m_hasMyTaxCollector = value;
            }
        }
        
        private byte m_teamMembersCount;
        
        public virtual byte TeamMembersCount
        {
            get
            {
                return m_teamMembersCount;
            }
            set
            {
                m_teamMembersCount = value;
            }
        }
        
        private uint m_meanLevel;
        
        public virtual uint MeanLevel
        {
            get
            {
                return m_meanLevel;
            }
            set
            {
                m_meanLevel = value;
            }
        }
        
        public FightTeamLightInformations(bool hasFriend, bool hasGuildMember, bool hasAllianceMember, bool hasGroupMember, bool hasMyTaxCollector, byte teamMembersCount, uint meanLevel)
        {
            m_hasFriend = hasFriend;
            m_hasGuildMember = hasGuildMember;
            m_hasAllianceMember = hasAllianceMember;
            m_hasGroupMember = hasGroupMember;
            m_hasMyTaxCollector = hasMyTaxCollector;
            m_teamMembersCount = teamMembersCount;
            m_meanLevel = meanLevel;
        }
        
        public FightTeamLightInformations()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            byte flag = new byte();
            BooleanByteWrapper.SetFlag(0, flag, m_hasFriend);
            BooleanByteWrapper.SetFlag(1, flag, m_hasGuildMember);
            BooleanByteWrapper.SetFlag(2, flag, m_hasAllianceMember);
            BooleanByteWrapper.SetFlag(3, flag, m_hasGroupMember);
            BooleanByteWrapper.SetFlag(4, flag, m_hasMyTaxCollector);
            writer.WriteByte(flag);
            writer.WriteByte(m_teamMembersCount);
            writer.WriteVarUhInt(m_meanLevel);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            byte flag = reader.ReadByte();
            m_hasFriend = BooleanByteWrapper.GetFlag(flag, 0);
            m_hasGuildMember = BooleanByteWrapper.GetFlag(flag, 1);
            m_hasAllianceMember = BooleanByteWrapper.GetFlag(flag, 2);
            m_hasGroupMember = BooleanByteWrapper.GetFlag(flag, 3);
            m_hasMyTaxCollector = BooleanByteWrapper.GetFlag(flag, 4);
            m_teamMembersCount = reader.ReadByte();
            m_meanLevel = reader.ReadVarUhInt();
        }
    }
}
