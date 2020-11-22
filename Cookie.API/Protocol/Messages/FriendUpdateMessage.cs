using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class FriendUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5924;

        public override ushort MessageID => ProtocolId;

        public FriendInformations FriendUpdated { get; set; }
        public FriendUpdateMessage() { }

        public FriendUpdateMessage( FriendInformations FriendUpdated ){
            this.FriendUpdated = FriendUpdated;
        }

        public override void Serialize(IDataWriter writer)
        {
            FriendUpdated.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            FriendUpdated = ProtocolTypeManager.GetInstance(reader.ReadUShort());
            FriendUpdated.Deserialize(reader);
        }
    }
}
