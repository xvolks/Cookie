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
    
    
    public class ExchangeMountSterilizeFromPaddockMessage : NetworkMessage
    {
        
        public const uint ProtocolId = 6056;
        
        public override uint MessageID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private string m_name;
        
        public virtual string Name
        {
            get
            {
                return m_name;
            }
            set
            {
                m_name = value;
            }
        }
        
        private short m_worldX;
        
        public virtual short WorldX
        {
            get
            {
                return m_worldX;
            }
            set
            {
                m_worldX = value;
            }
        }
        
        private short m_worldY;
        
        public virtual short WorldY
        {
            get
            {
                return m_worldY;
            }
            set
            {
                m_worldY = value;
            }
        }
        
        private string m_sterilizator;
        
        public virtual string Sterilizator
        {
            get
            {
                return m_sterilizator;
            }
            set
            {
                m_sterilizator = value;
            }
        }
        
        public ExchangeMountSterilizeFromPaddockMessage(string name, short worldX, short worldY, string sterilizator)
        {
            m_name = name;
            m_worldX = worldX;
            m_worldY = worldY;
            m_sterilizator = sterilizator;
        }
        
        public ExchangeMountSterilizeFromPaddockMessage()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteUTF(m_name);
            writer.WriteShort(m_worldX);
            writer.WriteShort(m_worldY);
            writer.WriteUTF(m_sterilizator);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            m_name = reader.ReadUTF();
            m_worldX = reader.ReadShort();
            m_worldY = reader.ReadShort();
            m_sterilizator = reader.ReadUTF();
        }
    }
}
