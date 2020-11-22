using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class FriendAddRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 4004;

        public override ushort MessageID => ProtocolId;

        public string Name { get; set; }
        public FriendAddRequestMessage() { }

        public FriendAddRequestMessage( string Name ){
            this.Name = Name;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Name);
        }

        public override void Deserialize(IDataReader reader)
        {
            Name = reader.ReadUTF();
        }
    }
}
