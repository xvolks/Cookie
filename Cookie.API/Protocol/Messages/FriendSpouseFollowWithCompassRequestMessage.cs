using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class FriendSpouseFollowWithCompassRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5606;

        public override ushort MessageID => ProtocolId;

        public bool Enable { get; set; }
        public FriendSpouseFollowWithCompassRequestMessage() { }

        public FriendSpouseFollowWithCompassRequestMessage( bool Enable ){
            this.Enable = Enable;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Enable);
        }

        public override void Deserialize(IDataReader reader)
        {
            Enable = reader.ReadBoolean();
        }
    }
}
