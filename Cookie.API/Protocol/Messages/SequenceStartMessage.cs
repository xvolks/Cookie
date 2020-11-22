using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class SequenceStartMessage : NetworkMessage
    {
        public const ushort ProtocolId = 955;

        public override ushort MessageID => ProtocolId;

        public sbyte SequenceType { get; set; }
        public double AuthorId { get; set; }
        public SequenceStartMessage() { }

        public SequenceStartMessage( sbyte SequenceType, double AuthorId ){
            this.SequenceType = SequenceType;
            this.AuthorId = AuthorId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(SequenceType);
            writer.WriteDouble(AuthorId);
        }

        public override void Deserialize(IDataReader reader)
        {
            SequenceType = reader.ReadSByte();
            AuthorId = reader.ReadDouble();
        }
    }
}
