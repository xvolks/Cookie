//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cookie.API.Protocol.Network.Messages.Game.Actions.Fight
{
    using System.Collections.Generic;
    using Cookie.API.Protocol.Network.Messages;
    using Cookie.API.Protocol.Network.Types;
    using Cookie.API.Utils.IO;
    
    
    public class GameActionFightCastRequestMessage : NetworkMessage
    {
        
        public const uint ProtocolId = 1005;
        
        public override uint MessageID
        {
            get
            {
                return ProtocolId;
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
        
        private short m_cellId;
        
        public virtual short CellId
        {
            get
            {
                return m_cellId;
            }
            set
            {
                m_cellId = value;
            }
        }
        
        public GameActionFightCastRequestMessage(ushort spellId, short cellId)
        {
            m_spellId = spellId;
            m_cellId = cellId;
        }
        
        public GameActionFightCastRequestMessage()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarUhShort(m_spellId);
            writer.WriteShort(m_cellId);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            m_spellId = reader.ReadVarUhShort();
            m_cellId = reader.ReadShort();
        }
    }
}
