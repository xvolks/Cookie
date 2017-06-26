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
    
    
    public class ExchangeBidPriceMessage : NetworkMessage
    {
        
        public const uint ProtocolId = 5755;
        
        public override uint MessageID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private ushort m_genericId;
        
        public virtual ushort GenericId
        {
            get
            {
                return m_genericId;
            }
            set
            {
                m_genericId = value;
            }
        }
        
        private long m_averagePrice;
        
        public virtual long AveragePrice
        {
            get
            {
                return m_averagePrice;
            }
            set
            {
                m_averagePrice = value;
            }
        }
        
        public ExchangeBidPriceMessage(ushort genericId, long averagePrice)
        {
            m_genericId = genericId;
            m_averagePrice = averagePrice;
        }
        
        public ExchangeBidPriceMessage()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarUhShort(m_genericId);
            writer.WriteVarLong(m_averagePrice);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            m_genericId = reader.ReadVarUhShort();
            m_averagePrice = reader.ReadVarLong();
        }
    }
}
