//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cookie.API.Protocol.Network.Messages.Game.Pvp
{
    using System.Collections.Generic;
    using Cookie.API.Protocol.Network.Messages;
    using Cookie.API.Protocol.Network.Types;
    using Cookie.API.Utils.IO;
    
    
    public class UpdateMapPlayersAgressableStatusMessage : NetworkMessage
    {
        
        public const uint ProtocolId = 6454;
        
        public override uint MessageID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private List<System.UInt64> m_playerIds;
        
        public virtual List<System.UInt64> PlayerIds
        {
            get
            {
                return m_playerIds;
            }
            set
            {
                m_playerIds = value;
            }
        }
        
        private List<System.Byte> m_enable;
        
        public virtual List<System.Byte> Enable
        {
            get
            {
                return m_enable;
            }
            set
            {
                m_enable = value;
            }
        }
        
        public UpdateMapPlayersAgressableStatusMessage(List<System.UInt64> playerIds, List<System.Byte> enable)
        {
            m_playerIds = playerIds;
            m_enable = enable;
        }
        
        public UpdateMapPlayersAgressableStatusMessage()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort(((short)(m_playerIds.Count)));
            int playerIdsIndex;
            for (playerIdsIndex = 0; (playerIdsIndex < m_playerIds.Count); playerIdsIndex = (playerIdsIndex + 1))
            {
                writer.WriteVarUhLong(m_playerIds[playerIdsIndex]);
            }
            writer.WriteShort(((short)(m_enable.Count)));
            int enableIndex;
            for (enableIndex = 0; (enableIndex < m_enable.Count); enableIndex = (enableIndex + 1))
            {
                writer.WriteByte(m_enable[enableIndex]);
            }
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            int playerIdsCount = reader.ReadUShort();
            int playerIdsIndex;
            m_playerIds = new System.Collections.Generic.List<ulong>();
            for (playerIdsIndex = 0; (playerIdsIndex < playerIdsCount); playerIdsIndex = (playerIdsIndex + 1))
            {
                m_playerIds.Add(reader.ReadVarUhLong());
            }
            int enableCount = reader.ReadUShort();
            int enableIndex;
            m_enable = new System.Collections.Generic.List<byte>();
            for (enableIndex = 0; (enableIndex < enableCount); enableIndex = (enableIndex + 1))
            {
                m_enable.Add(reader.ReadByte());
            }
        }
    }
}
