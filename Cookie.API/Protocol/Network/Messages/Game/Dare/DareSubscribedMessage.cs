//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cookie.API.Protocol.Network.Messages.Game.Dare
{
    using Cookie.API.Protocol.Network.Types.Game.Dare;
    using System.Collections.Generic;
    using Cookie.API.Protocol.Network.Messages;
    using Cookie.API.Protocol.Network.Types;
    using Cookie.API.Utils.IO;
    
    
    public class DareSubscribedMessage : NetworkMessage
    {
        
        public const uint ProtocolId = 6660;
        
        public override uint MessageID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private bool m_success;
        
        public virtual bool Success
        {
            get
            {
                return m_success;
            }
            set
            {
                m_success = value;
            }
        }
        
        private bool m_subscribe;
        
        public virtual bool Subscribe
        {
            get
            {
                return m_subscribe;
            }
            set
            {
                m_subscribe = value;
            }
        }
        
        private DareVersatileInformations m_dareVersatilesInfos;
        
        public virtual DareVersatileInformations DareVersatilesInfos
        {
            get
            {
                return m_dareVersatilesInfos;
            }
            set
            {
                m_dareVersatilesInfos = value;
            }
        }
        
        private double m_dareId;
        
        public virtual double DareId
        {
            get
            {
                return m_dareId;
            }
            set
            {
                m_dareId = value;
            }
        }
        
        public DareSubscribedMessage(bool success, bool subscribe, DareVersatileInformations dareVersatilesInfos, double dareId)
        {
            m_success = success;
            m_subscribe = subscribe;
            m_dareVersatilesInfos = dareVersatilesInfos;
            m_dareId = dareId;
        }
        
        public DareSubscribedMessage()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            byte flag = new byte();
            BooleanByteWrapper.SetFlag(0, flag, m_success);
            BooleanByteWrapper.SetFlag(1, flag, m_subscribe);
            writer.WriteByte(flag);
            m_dareVersatilesInfos.Serialize(writer);
            writer.WriteDouble(m_dareId);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            byte flag = reader.ReadByte();
            m_success = BooleanByteWrapper.GetFlag(flag, 0);
            m_subscribe = BooleanByteWrapper.GetFlag(flag, 1);
            m_dareVersatilesInfos = new DareVersatileInformations();
            m_dareVersatilesInfos.Deserialize(reader);
            m_dareId = reader.ReadDouble();
        }
    }
}
