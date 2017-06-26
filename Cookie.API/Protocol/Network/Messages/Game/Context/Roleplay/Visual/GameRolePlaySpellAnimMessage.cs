//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Visual
{
    using System.Collections.Generic;
    using Cookie.API.Protocol.Network.Messages;
    using Cookie.API.Protocol.Network.Types;
    using Cookie.API.Utils.IO;
    
    
    public class GameRolePlaySpellAnimMessage : NetworkMessage
    {
        
        public const uint ProtocolId = 6114;
        
        public override uint MessageID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private ulong m_casterId;
        
        public virtual ulong CasterId
        {
            get
            {
                return m_casterId;
            }
            set
            {
                m_casterId = value;
            }
        }
        
        private ushort m_targetCellId;
        
        public virtual ushort TargetCellId
        {
            get
            {
                return m_targetCellId;
            }
            set
            {
                m_targetCellId = value;
            }
        }
        
        private ushort m_spellId;
        
        public virtual ushort SpellId
        {
            get
            {
                return m_spellId;
            }
            set
            {
                m_spellId = value;
            }
        }
        
        private short m_spellLevel;
        
        public virtual short SpellLevel
        {
            get
            {
                return m_spellLevel;
            }
            set
            {
                m_spellLevel = value;
            }
        }
        
        public GameRolePlaySpellAnimMessage(ulong casterId, ushort targetCellId, ushort spellId, short spellLevel)
        {
            m_casterId = casterId;
            m_targetCellId = targetCellId;
            m_spellId = spellId;
            m_spellLevel = spellLevel;
        }
        
        public GameRolePlaySpellAnimMessage()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarUhLong(m_casterId);
            writer.WriteVarUhShort(m_targetCellId);
            writer.WriteVarUhShort(m_spellId);
            writer.WriteShort(m_spellLevel);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            m_casterId = reader.ReadVarUhLong();
            m_targetCellId = reader.ReadVarUhShort();
            m_spellId = reader.ReadVarUhShort();
            m_spellLevel = reader.ReadShort();
        }
    }
}
