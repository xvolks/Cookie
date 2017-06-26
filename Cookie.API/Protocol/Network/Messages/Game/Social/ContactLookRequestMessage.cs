//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cookie.API.Protocol.Network.Messages.Game.Social
{
    using System.Collections.Generic;
    using Cookie.API.Protocol.Network.Messages;
    using Cookie.API.Protocol.Network.Types;
    using Cookie.API.Utils.IO;
    
    
    public class ContactLookRequestMessage : NetworkMessage
    {
        
        public const uint ProtocolId = 5932;
        
        public override uint MessageID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private sbyte m_requestId;
        
        public virtual sbyte RequestId
        {
            get
            {
                return m_requestId;
            }
            set
            {
                m_requestId = value;
            }
        }
        
        private byte m_contactType;
        
        public virtual byte ContactType
        {
            get
            {
                return m_contactType;
            }
            set
            {
                m_contactType = value;
            }
        }
        
        public ContactLookRequestMessage(sbyte requestId, byte contactType)
        {
            m_requestId = requestId;
            m_contactType = contactType;
        }
        
        public ContactLookRequestMessage()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteSByte(m_requestId);
            writer.WriteByte(m_contactType);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            m_requestId = reader.ReadSByte();
            m_contactType = reader.ReadByte();
        }
    }
}
