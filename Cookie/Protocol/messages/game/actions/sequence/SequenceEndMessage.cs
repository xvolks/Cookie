using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class SequenceEndMessage : NetworkMessage
    {
        public const uint ProtocolId = 956;
        public override uint MessageID { get { return ProtocolId; } }

        public short ActionId = 0;
        public double AuthorId = 0;
        public byte SequenceType = 0;

        public SequenceEndMessage()
        {
        }

        public SequenceEndMessage(
            short actionId,
            double authorId,
            byte sequenceType
        )
        {
            ActionId = actionId;
            AuthorId = authorId;
            SequenceType = sequenceType;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(ActionId);
            writer.WriteDouble(AuthorId);
            writer.WriteByte(SequenceType);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ActionId = reader.ReadVarShort();
            AuthorId = reader.ReadDouble();
            SequenceType = reader.ReadByte();
        }
    }
}