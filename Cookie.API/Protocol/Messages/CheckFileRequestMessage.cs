using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class CheckFileRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6154;

        public override ushort MessageID => ProtocolId;

        public string Filename { get; set; }
        public sbyte Type { get; set; }
        public CheckFileRequestMessage() { }

        public CheckFileRequestMessage( string Filename, sbyte Type ){
            this.Filename = Filename;
            this.Type = Type;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Filename);
            writer.WriteSByte(Type);
        }

        public override void Deserialize(IDataReader reader)
        {
            Filename = reader.ReadUTF();
            Type = reader.ReadSByte();
        }
    }
}
