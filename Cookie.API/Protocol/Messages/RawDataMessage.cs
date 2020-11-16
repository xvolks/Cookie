using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class RawDataMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6253;

        public override ushort MessageID => ProtocolId;

        public byte[] Content { get; set; }
        public RawDataMessage() { }

        public RawDataMessage( byte[] Content ){
            this.Content = Content;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarInt(Content.Length);
            writer.WriteBytes(Content);
        }

        public override void Deserialize(IDataReader reader)
        {
            Content = reader.ReadBytes(reader.ReadVarInt());
        }
    }
}
