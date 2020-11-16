using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PlayerStatusUpdateRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6387;

        public override ushort MessageID => ProtocolId;

        public PlayerStatus Status { get; set; }
        public PlayerStatusUpdateRequestMessage() { }

        public PlayerStatusUpdateRequestMessage( PlayerStatus Status ){
            this.Status = Status;
        }

        public override void Serialize(IDataWriter writer)
        {
            Status.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Status = ProtocolTypeManager.GetInstance(reader.ReadUShort());
            Status.Deserialize(reader);
        }
    }
}
