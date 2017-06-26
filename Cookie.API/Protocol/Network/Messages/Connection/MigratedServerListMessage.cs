//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cookie.API.Protocol.Network.Messages.Connection
{
    using System.Collections.Generic;
    using Cookie.API.Protocol.Network.Messages;
    using Cookie.API.Protocol.Network.Types;
    using Cookie.API.Utils.IO;
    
    
    public class MigratedServerListMessage : NetworkMessage
    {
        
        public const uint ProtocolId = 6731;
        
        public override uint MessageID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private List<System.UInt16> m_migratedServerIds;
        
        public virtual List<System.UInt16> MigratedServerIds
        {
            get
            {
                return m_migratedServerIds;
            }
            set
            {
                m_migratedServerIds = value;
            }
        }
        
        public MigratedServerListMessage(List<System.UInt16> migratedServerIds)
        {
            m_migratedServerIds = migratedServerIds;
        }
        
        public MigratedServerListMessage()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort(((short)(m_migratedServerIds.Count)));
            int migratedServerIdsIndex;
            for (migratedServerIdsIndex = 0; (migratedServerIdsIndex < m_migratedServerIds.Count); migratedServerIdsIndex = (migratedServerIdsIndex + 1))
            {
                writer.WriteVarUhShort(m_migratedServerIds[migratedServerIdsIndex]);
            }
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            int migratedServerIdsCount = reader.ReadUShort();
            int migratedServerIdsIndex;
            m_migratedServerIds = new System.Collections.Generic.List<ushort>();
            for (migratedServerIdsIndex = 0; (migratedServerIdsIndex < migratedServerIdsCount); migratedServerIdsIndex = (migratedServerIdsIndex + 1))
            {
                m_migratedServerIds.Add(reader.ReadVarUhShort());
            }
        }
    }
}
