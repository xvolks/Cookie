//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Houses
{
    using System.Collections.Generic;
    using Cookie.API.Protocol.Network.Messages;
    using Cookie.API.Protocol.Network.Types;
    using Cookie.API.Utils.IO;
    
    
    public class HouseToSellListRequestMessage : NetworkMessage
    {
        
        public const uint ProtocolId = 6139;
        
        public override uint MessageID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private ushort m_pageIndex;
        
        public virtual ushort PageIndex
        {
            get
            {
                return m_pageIndex;
            }
            set
            {
                m_pageIndex = value;
            }
        }
        
        public HouseToSellListRequestMessage(ushort pageIndex)
        {
            m_pageIndex = pageIndex;
        }
        
        public HouseToSellListRequestMessage()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarUhShort(m_pageIndex);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            m_pageIndex = reader.ReadVarUhShort();
        }
    }
}
