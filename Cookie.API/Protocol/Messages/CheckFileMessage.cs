using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class CheckFileMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6156;

        public override ushort MessageID => ProtocolId;

        public string FilenameHash { get; set; }
        public sbyte Type { get; set; }
        public string Value { get; set; }
        public CheckFileMessage() { }

        public CheckFileMessage( string FilenameHash, sbyte Type, string Value ){
            this.FilenameHash = FilenameHash;
            this.Type = Type;
            this.Value = Value;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(FilenameHash);
            writer.WriteSByte(Type);
            writer.WriteUTF(Value);
        }

        public override void Deserialize(IDataReader reader)
        {
            FilenameHash = reader.ReadUTF();
            Type = reader.ReadSByte();
            Value = reader.ReadUTF();
        }
    }
}
