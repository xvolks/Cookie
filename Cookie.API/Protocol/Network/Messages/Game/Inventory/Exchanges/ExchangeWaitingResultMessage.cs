//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Exchanges
{
    using System.Collections.Generic;
    using Cookie.API.Protocol.Network.Messages;
    using Cookie.API.Protocol.Network.Types;
    using Cookie.API.Utils.IO;
    
    
    public class ExchangeWaitingResultMessage : NetworkMessage
    {
        
        public const uint ProtocolId = 5786;
        
        public override uint MessageID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private bool m_bwait;
        
        public virtual bool Bwait
        {
            get
            {
                return m_bwait;
            }
            set
            {
                m_bwait = value;
            }
        }
        
        public ExchangeWaitingResultMessage(bool bwait)
        {
            m_bwait = bwait;
        }
        
        public ExchangeWaitingResultMessage()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteBoolean(m_bwait);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            m_bwait = reader.ReadBoolean();
        }
    }
}
