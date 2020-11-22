using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ChatCommunityChannelCommunityMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6730;

        public override ushort MessageID => ProtocolId;

        public short CommunityId { get; set; }
        public ChatCommunityChannelCommunityMessage() { }

        public ChatCommunityChannelCommunityMessage( short CommunityId ){
            this.CommunityId = CommunityId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(CommunityId);
        }

        public override void Deserialize(IDataReader reader)
        {
            CommunityId = reader.ReadShort();
        }
    }
}
