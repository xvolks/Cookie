using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class FriendAddedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5599;

        public override ushort MessageID => ProtocolId;

        public FriendInformations FriendAdded { get; set; }
        public FriendAddedMessage() { }

        public FriendAddedMessage( FriendInformations FriendAdded ){
            this.FriendAdded = FriendAdded;
        }

        public override void Serialize(IDataWriter writer)
        {
            FriendAdded.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            FriendAdded = ProtocolTypeManager.GetInstance(reader.ReadUShort());
            FriendAdded.Deserialize(reader);
        }
    }
}
