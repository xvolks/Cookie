//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cookie.API.Protocol.Network.Messages.Game.Context
{
    using Cookie.API.Protocol.Network.Types.Game.Context;
    using System.Collections.Generic;
    using Cookie.API.Protocol.Network.Messages;
    using Cookie.API.Protocol.Network.Types;
    using Cookie.API.Utils.IO;
    
    
    public class GameEntityDispositionMessage : NetworkMessage
    {
        
        public const uint ProtocolId = 5693;
        
        public override uint MessageID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private IdentifiedEntityDispositionInformations m_disposition;
        
        public virtual IdentifiedEntityDispositionInformations Disposition
        {
            get
            {
                return m_disposition;
            }
            set
            {
                m_disposition = value;
            }
        }
        
        public GameEntityDispositionMessage(IdentifiedEntityDispositionInformations disposition)
        {
            m_disposition = disposition;
        }
        
        public GameEntityDispositionMessage()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            m_disposition.Serialize(writer);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            m_disposition = new IdentifiedEntityDispositionInformations();
            m_disposition.Deserialize(reader);
        }
    }
}
