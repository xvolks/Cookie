using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class FriendStatusShareStateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6823;

        public override ushort MessageID => ProtocolId;

        public bool Share { get; set; }
        public FriendStatusShareStateMessage() { }

        public FriendStatusShareStateMessage( bool Share ){
            this.Share = Share;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Share);
        }

        public override void Deserialize(IDataReader reader)
        {
            Share = reader.ReadBoolean();
        }
    }
}
