using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class FriendDeleteResultMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5601;

        public override ushort MessageID => ProtocolId;

        public bool Success { get; set; }
        public string Name { get; set; }
        public FriendDeleteResultMessage() { }

        public FriendDeleteResultMessage( bool Success, string Name ){
            this.Success = Success;
            this.Name = Name;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Success);
            writer.WriteUTF(Name);
        }

        public override void Deserialize(IDataReader reader)
        {
            Success = reader.ReadBoolean();
            Name = reader.ReadUTF();
        }
    }
}
