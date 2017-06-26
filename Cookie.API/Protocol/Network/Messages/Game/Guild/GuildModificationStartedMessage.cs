//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    using System.Collections.Generic;
    using Cookie.API.Protocol.Network.Messages;
    using Cookie.API.Protocol.Network.Types;
    using Cookie.API.Utils.IO;
    
    
    public class GuildModificationStartedMessage : NetworkMessage
    {
        
        public const uint ProtocolId = 6324;
        
        public override uint MessageID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private bool m_canChangeName;
        
        public virtual bool CanChangeName
        {
            get
            {
                return m_canChangeName;
            }
            set
            {
                m_canChangeName = value;
            }
        }
        
        private bool m_canChangeEmblem;
        
        public virtual bool CanChangeEmblem
        {
            get
            {
                return m_canChangeEmblem;
            }
            set
            {
                m_canChangeEmblem = value;
            }
        }
        
        public GuildModificationStartedMessage(bool canChangeName, bool canChangeEmblem)
        {
            m_canChangeName = canChangeName;
            m_canChangeEmblem = canChangeEmblem;
        }
        
        public GuildModificationStartedMessage()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            byte flag = new byte();
            BooleanByteWrapper.SetFlag(0, flag, m_canChangeName);
            BooleanByteWrapper.SetFlag(1, flag, m_canChangeEmblem);
            writer.WriteByte(flag);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            byte flag = reader.ReadByte();
            m_canChangeName = BooleanByteWrapper.GetFlag(flag, 0);
            m_canChangeEmblem = BooleanByteWrapper.GetFlag(flag, 1);
        }
    }
}
