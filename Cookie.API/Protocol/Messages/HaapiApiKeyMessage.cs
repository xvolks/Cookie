using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class HaapiApiKeyMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6649;

        public override ushort MessageID => ProtocolId;

        public string Token { get; set; }
        public HaapiApiKeyMessage() { }

        public HaapiApiKeyMessage( string Token ){
            this.Token = Token;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Token);
        }

        public override void Deserialize(IDataReader reader)
        {
            Token = reader.ReadUTF();
        }
    }
}
