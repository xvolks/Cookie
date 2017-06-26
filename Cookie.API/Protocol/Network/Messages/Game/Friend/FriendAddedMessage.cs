//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cookie.API.Protocol.Network.Messages.Game.Friend
{
    using Cookie.API.Protocol.Network.Types.Game.Friend;
    
    using System.Collections.Generic;
    using Cookie.API.Protocol.Network.Messages;
    using Cookie.API.Protocol.Network.Types;
    using Cookie.API.Utils.IO;
    
    
    public class FriendAddedMessage : NetworkMessage
    {
        
        public const uint ProtocolId = 5599;
        
        public override uint MessageID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        private FriendInformations m_friendAdded;
        
        public virtual FriendInformations FriendAdded
        {
            get
            {
                return m_friendAdded;
            }
            set
            {
                m_friendAdded = value;
            }
        }
        
        public FriendAddedMessage(FriendInformations friendAdded)
        {
            m_friendAdded = friendAdded;
        }
        
        public FriendAddedMessage()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteUShort(((ushort)(m_friendAdded.TypeID)));
            m_friendAdded.Serialize(writer);
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
            m_friendAdded = ProtocolTypeManager.GetInstance<FriendInformations>((short)reader.ReadUShort());
            m_friendAdded.Deserialize(reader);
        }
    }
}
