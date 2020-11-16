using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class SequenceStartMessage : NetworkMessage
    {
        public const uint ProtocolId = 955;
        public override uint MessageID { get { return ProtocolId; } }

        public byte SequenceType = 0;
        public double AuthorId = 0;

        public SequenceStartMessage()
        {
        }

        public SequenceStartMessage(
            byte sequenceType,
            double authorId
        )
        {
            SequenceType = sequenceType;
            AuthorId = authorId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(SequenceType);
            writer.WriteDouble(AuthorId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            SequenceType = reader.ReadByte();
            AuthorId = reader.ReadDouble();
        }
    }
}