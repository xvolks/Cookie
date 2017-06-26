//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cookie.API.Protocol.Network.Messages.Game.Guild.Tax
{
    using System.Collections.Generic;
    using Cookie.API.Protocol.Network.Messages;
    using Cookie.API.Protocol.Network.Types;
    using Cookie.API.Utils.IO;
    
    
    public class TaxCollectorMovementRemoveMessage : NetworkMessage
    {
        
        public const uint ProtocolId = 5915;
        
        public override uint MessageID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private int m_collectorId;
        
        public virtual int CollectorId
        {
            get
            {
                return m_collectorId;
            }
            set
            {
                m_collectorId = value;
            }
        }
        
        public TaxCollectorMovementRemoveMessage(int collectorId)
        {
            m_collectorId = collectorId;
        }
        
        public TaxCollectorMovementRemoveMessage()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(m_collectorId);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            m_collectorId = reader.ReadInt();
        }
    }
}
