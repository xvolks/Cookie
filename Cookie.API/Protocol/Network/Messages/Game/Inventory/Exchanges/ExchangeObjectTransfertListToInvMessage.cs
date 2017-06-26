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
    
    
    public class ExchangeObjectTransfertListToInvMessage : NetworkMessage
    {
        
        public const uint ProtocolId = 6039;
        
        public override uint MessageID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private List<System.UInt32> m_ids;
        
        public virtual List<System.UInt32> Ids
        {
            get
            {
                return m_ids;
            }
            set
            {
                m_ids = value;
            }
        }
        
        public ExchangeObjectTransfertListToInvMessage(List<System.UInt32> ids)
        {
            m_ids = ids;
        }
        
        public ExchangeObjectTransfertListToInvMessage()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort(((short)(m_ids.Count)));
            int idsIndex;
            for (idsIndex = 0; (idsIndex < m_ids.Count); idsIndex = (idsIndex + 1))
            {
                writer.WriteVarUhInt(m_ids[idsIndex]);
            }
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            int idsCount = reader.ReadUShort();
            int idsIndex;
            m_ids = new System.Collections.Generic.List<uint>();
            for (idsIndex = 0; (idsIndex < idsCount); idsIndex = (idsIndex + 1))
            {
                m_ids.Add(reader.ReadVarUhInt());
            }
        }
    }
}
