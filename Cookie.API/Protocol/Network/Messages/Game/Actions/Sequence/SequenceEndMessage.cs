using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Actions.Sequence
{
    public class SequenceEndMessage : NetworkMessage
    {
        public const ushort ProtocolId = 956;

        public SequenceEndMessage(ushort actionId, double authorId, sbyte sequenceType)
        {
            ActionId = actionId;
            AuthorId = authorId;
            SequenceType = sequenceType;
        }

        public SequenceEndMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort ActionId { get; set; }
        public double AuthorId { get; set; }
        public sbyte SequenceType { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(ActionId);
            writer.WriteDouble(AuthorId);
            writer.WriteSByte(SequenceType);
        }

        public override void Deserialize(IDataReader reader)
        {
            ActionId = reader.ReadVarUhShort();
            AuthorId = reader.ReadDouble();
            SequenceType = reader.ReadSByte();
        }
    }
}