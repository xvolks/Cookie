//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Fight.Arena
{
    using System.Collections.Generic;
    using Cookie.API.Protocol.Network.Messages;
    using Cookie.API.Protocol.Network.Types;
    using Cookie.API.Utils.IO;
    
    
    public class GameRolePlayArenaSwitchToGameServerMessage : NetworkMessage
    {
        
        public const uint ProtocolId = 6574;
        
        public override uint MessageID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private List<System.Byte> m_ticket;
        
        public virtual List<System.Byte> Ticket
        {
            get
            {
                return m_ticket;
            }
            set
            {
                m_ticket = value;
            }
        }
        
        private bool m_validToken;
        
        public virtual bool ValidToken
        {
            get
            {
                return m_validToken;
            }
            set
            {
                m_validToken = value;
            }
        }
        
        private short m_homeServerId;
        
        public virtual short HomeServerId
        {
            get
            {
                return m_homeServerId;
            }
            set
            {
                m_homeServerId = value;
            }
        }
        
        public GameRolePlayArenaSwitchToGameServerMessage(List<System.Byte> ticket, bool validToken, short homeServerId)
        {
            m_ticket = ticket;
            m_validToken = validToken;
            m_homeServerId = homeServerId;
        }
        
        public GameRolePlayArenaSwitchToGameServerMessage()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort(((short)(m_ticket.Count)));
            int ticketIndex;
            for (ticketIndex = 0; (ticketIndex < m_ticket.Count); ticketIndex = (ticketIndex + 1))
            {
                writer.WriteByte(m_ticket[ticketIndex]);
            }
            writer.WriteBoolean(m_validToken);
            writer.WriteShort(m_homeServerId);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            int ticketCount = reader.ReadUShort();
            int ticketIndex;
            m_ticket = new System.Collections.Generic.List<byte>();
            for (ticketIndex = 0; (ticketIndex < ticketCount); ticketIndex = (ticketIndex + 1))
            {
                m_ticket.Add(reader.ReadByte());
            }
            m_validToken = reader.ReadBoolean();
            m_homeServerId = reader.ReadShort();
        }
    }
}
