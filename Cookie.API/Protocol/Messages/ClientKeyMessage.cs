using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ClientKeyMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5607;

        public override ushort MessageID => ProtocolId;

        public string Key { get; set; }
        public ClientKeyMessage() { }

        public ClientKeyMessage( string Key ){
            this.Key = Key;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Key);
        }

        public override void Deserialize(IDataReader reader)
        {
            Key = reader.ReadUTF();
        }
    }
}
