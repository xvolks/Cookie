//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay
{
    using System.Collections.Generic;
    using Cookie.API.Protocol.Network.Messages;
    using Cookie.API.Protocol.Network.Types;
    using Cookie.API.Utils.IO;
    
    
    public class GroupMonsterStaticInformations : NetworkType
    {
        
        public const short ProtocolId = 140;
        
        public override short TypeID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private MonsterInGroupLightInformations m_mainCreatureLightInfos;
        
        public virtual MonsterInGroupLightInformations MainCreatureLightInfos
        {
            get
            {
                return m_mainCreatureLightInfos;
            }
            set
            {
                m_mainCreatureLightInfos = value;
            }
        }
        
        private List<MonsterInGroupInformations> m_underlings;
        
        public virtual List<MonsterInGroupInformations> Underlings
        {
            get
            {
                return m_underlings;
            }
            set
            {
                m_underlings = value;
            }
        }
        
        public GroupMonsterStaticInformations(MonsterInGroupLightInformations mainCreatureLightInfos, List<MonsterInGroupInformations> underlings)
        {
            m_mainCreatureLightInfos = mainCreatureLightInfos;
            m_underlings = underlings;
        }
        
        public GroupMonsterStaticInformations()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            m_mainCreatureLightInfos.Serialize(writer);
            writer.WriteShort(((short)(m_underlings.Count)));
            int underlingsIndex;
            for (underlingsIndex = 0; (underlingsIndex < m_underlings.Count); underlingsIndex = (underlingsIndex + 1))
            {
                MonsterInGroupInformations objectToSend = m_underlings[underlingsIndex];
                objectToSend.Serialize(writer);
            }
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            m_mainCreatureLightInfos = new MonsterInGroupLightInformations();
            m_mainCreatureLightInfos.Deserialize(reader);
            int underlingsCount = reader.ReadUShort();
            int underlingsIndex;
            m_underlings = new System.Collections.Generic.List<MonsterInGroupInformations>();
            for (underlingsIndex = 0; (underlingsIndex < underlingsCount); underlingsIndex = (underlingsIndex + 1))
            {
                MonsterInGroupInformations objectToAdd = new MonsterInGroupInformations();
                objectToAdd.Deserialize(reader);
                m_underlings.Add(objectToAdd);
            }
        }
    }
}
