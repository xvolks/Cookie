//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cookie.API.Protocol.Network.Messages.Game.Idol
{
    using System.Collections.Generic;
    using Cookie.API.Protocol.Network.Messages;
    using Cookie.API.Protocol.Network.Types;
    using Cookie.API.Utils.IO;
    
    
    public class IdolSelectErrorMessage : NetworkMessage
    {
        
        public const uint ProtocolId = 6584;
        
        public override uint MessageID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private bool m_activate;
        
        public virtual bool Activate
        {
            get
            {
                return m_activate;
            }
            set
            {
                m_activate = value;
            }
        }
        
        private bool m_party;
        
        public virtual bool Party
        {
            get
            {
                return m_party;
            }
            set
            {
                m_party = value;
            }
        }
        
        private byte m_reason;
        
        public virtual byte Reason
        {
            get
            {
                return m_reason;
            }
            set
            {
                m_reason = value;
            }
        }
        
        private ushort m_idolId;
        
        public virtual ushort IdolId
        {
            get
            {
                return m_idolId;
            }
            set
            {
                m_idolId = value;
            }
        }
        
        public IdolSelectErrorMessage(bool activate, bool party, byte reason, ushort idolId)
        {
            m_activate = activate;
            m_party = party;
            m_reason = reason;
            m_idolId = idolId;
        }
        
        public IdolSelectErrorMessage()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            byte flag = new byte();
            BooleanByteWrapper.SetFlag(0, flag, m_activate);
            BooleanByteWrapper.SetFlag(1, flag, m_party);
            writer.WriteByte(flag);
            writer.WriteByte(m_reason);
            writer.WriteVarUhShort(m_idolId);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            byte flag = reader.ReadByte();
            m_activate = BooleanByteWrapper.GetFlag(flag, 0);
            m_party = BooleanByteWrapper.GetFlag(flag, 1);
            m_reason = reader.ReadByte();
            m_idolId = reader.ReadVarUhShort();
        }
    }
}
