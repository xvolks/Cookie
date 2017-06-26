//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cookie.API.Protocol.Network.Messages.Game.Interactive.Meeting
{
    using System.Collections.Generic;
    using Cookie.API.Protocol.Network.Messages;
    using Cookie.API.Protocol.Network.Types;
    using Cookie.API.Utils.IO;
    
    
    public class TeleportBuddiesRequestedMessage : NetworkMessage
    {
        
        public const uint ProtocolId = 6302;
        
        public override uint MessageID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private List<System.UInt64> m_invalidBuddiesIds;
        
        public virtual List<System.UInt64> InvalidBuddiesIds
        {
            get
            {
                return m_invalidBuddiesIds;
            }
            set
            {
                m_invalidBuddiesIds = value;
            }
        }
        
        private ushort m_dungeonId;
        
        public virtual ushort DungeonId
        {
            get
            {
                return m_dungeonId;
            }
            set
            {
                m_dungeonId = value;
            }
        }
        
        private ulong m_inviterId;
        
        public virtual ulong InviterId
        {
            get
            {
                return m_inviterId;
            }
            set
            {
                m_inviterId = value;
            }
        }
        
        public TeleportBuddiesRequestedMessage(List<System.UInt64> invalidBuddiesIds, ushort dungeonId, ulong inviterId)
        {
            m_invalidBuddiesIds = invalidBuddiesIds;
            m_dungeonId = dungeonId;
            m_inviterId = inviterId;
        }
        
        public TeleportBuddiesRequestedMessage()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort(((short)(m_invalidBuddiesIds.Count)));
            int invalidBuddiesIdsIndex;
            for (invalidBuddiesIdsIndex = 0; (invalidBuddiesIdsIndex < m_invalidBuddiesIds.Count); invalidBuddiesIdsIndex = (invalidBuddiesIdsIndex + 1))
            {
                writer.WriteVarUhLong(m_invalidBuddiesIds[invalidBuddiesIdsIndex]);
            }
            writer.WriteVarUhShort(m_dungeonId);
            writer.WriteVarUhLong(m_inviterId);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            int invalidBuddiesIdsCount = reader.ReadUShort();
            int invalidBuddiesIdsIndex;
            m_invalidBuddiesIds = new System.Collections.Generic.List<ulong>();
            for (invalidBuddiesIdsIndex = 0; (invalidBuddiesIdsIndex < invalidBuddiesIdsCount); invalidBuddiesIdsIndex = (invalidBuddiesIdsIndex + 1))
            {
                m_invalidBuddiesIds.Add(reader.ReadVarUhLong());
            }
            m_dungeonId = reader.ReadVarUhShort();
            m_inviterId = reader.ReadVarUhLong();
        }
    }
}
