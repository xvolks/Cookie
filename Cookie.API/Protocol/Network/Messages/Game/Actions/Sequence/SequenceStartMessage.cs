using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Actions.Sequence
{
    public class SequenceStartMessage : NetworkMessage
    {
        public const ushort ProtocolId = 955;

        public SequenceStartMessage(sbyte sequenceType, double authorId)
        {
            SequenceType = sequenceType;
            AuthorId = authorId;
        }

        public SequenceStartMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public sbyte SequenceType { get; set; }
        public double AuthorId { get; set; }

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