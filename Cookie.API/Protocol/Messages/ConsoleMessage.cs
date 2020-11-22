using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ConsoleMessage : NetworkMessage
    {
        public const ushort ProtocolId = 75;

        public override ushort MessageID => ProtocolId;

        public sbyte Type { get; set; }
        public string Content { get; set; }
        public ConsoleMessage() { }

        public ConsoleMessage( sbyte Type, string Content ){
            this.Type = Type;
            this.Content = Content;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Type);
            writer.WriteUTF(Content);
        }

        public override void Deserialize(IDataReader reader)
        {
            Type = reader.ReadSByte();
            Content = reader.ReadUTF();
        }
    }
}
