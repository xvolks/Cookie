//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Mount
{
    using System.Collections.Generic;
    using Cookie.API.Protocol.Network.Messages;
    using Cookie.API.Protocol.Network.Types;
    using Cookie.API.Utils.IO;
    
    
    public class MountToggleRidingRequestMessage : NetworkMessage
    {
        
        public const uint ProtocolId = 5976;
        
        public override uint MessageID
        {
            get
            {
                return ProtocolId;
            }
        }
        
        public MountToggleRidingRequestMessage()
        {
        }
        
        public override void Serialize(ICustomDataOutput writer)
        {
        }
        
        public override void Deserialize(ICustomDataInput reader)
        {
        }
    }
}
