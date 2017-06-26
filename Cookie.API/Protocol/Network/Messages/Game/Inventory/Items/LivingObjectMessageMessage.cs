//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cookie.API.Protocol.Network.Messages.Game.Inventory.Items
{
    using System.Collections.Generic;
    using Cookie.API.Protocol.Network.Messages;
    using Cookie.API.Protocol.Network.Types;
    using Cookie.API.Utils.IO;
    
    
    public class LivingObjectMessageMessage : NetworkMessage
    {
        
        public const uint ProtocolId = 6065;
        
        public override uint MessageID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private ushort m_msgId;
        
        public virtual ushort MsgId
        {
            get
            {
                return m_msgId;
            }
            set
            {
                m_msgId = value;
            }
        }
        
        private int m_timeStamp;
        
        public virtual int TimeStamp
        {
            get
            {
                return m_timeStamp;
            }
            set
            {
                m_timeStamp = value;
            }
        }
        
        private string m_owner;
        
        public virtual string Owner
        {
            get
            {
                return m_owner;
            }
            set
            {
                m_owner = value;
            }
        }
        
        private ushort m_objectGenericId;
        
        public virtual ushort ObjectGenericId
        {
            get
            {
                return m_objectGenericId;
            }
            set
            {
                m_objectGenericId = value;
            }
        }
        
        public LivingObjectMessageMessage(ushort msgId, int timeStamp, string owner, ushort objectGenericId)
        {
            m_msgId = msgId;
            m_timeStamp = timeStamp;
            m_owner = owner;
            m_objectGenericId = objectGenericId;
        }
        
        public LivingObjectMessageMessage()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarUhShort(m_msgId);
            writer.WriteInt(m_timeStamp);
            writer.WriteUTF(m_owner);
            writer.WriteVarUhShort(m_objectGenericId);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            m_msgId = reader.ReadVarUhShort();
            m_timeStamp = reader.ReadInt();
            m_owner = reader.ReadUTF();
            m_objectGenericId = reader.ReadVarUhShort();
        }
    }
}
