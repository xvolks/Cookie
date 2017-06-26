//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.TreasureHunt
{
    using System.Collections.Generic;
    using Cookie.API.Protocol.Network.Messages;
    using Cookie.API.Protocol.Network.Types;
    using Cookie.API.Utils.IO;
    
    
    public class TreasureHuntFlagRemoveRequestMessage : NetworkMessage
    {
        
        public const uint ProtocolId = 6510;
        
        public override uint MessageID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private byte m_questType;
        
        public virtual byte QuestType
        {
            get
            {
                return m_questType;
            }
            set
            {
                m_questType = value;
            }
        }
        
        private byte m_index;
        
        public virtual byte Index
        {
            get
            {
                return m_index;
            }
            set
            {
                m_index = value;
            }
        }
        
        public TreasureHuntFlagRemoveRequestMessage(byte questType, byte index)
        {
            m_questType = questType;
            m_index = index;
        }
        
        public TreasureHuntFlagRemoveRequestMessage()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(m_questType);
            writer.WriteByte(m_index);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            m_questType = reader.ReadByte();
            m_index = reader.ReadByte();
        }
    }
}
