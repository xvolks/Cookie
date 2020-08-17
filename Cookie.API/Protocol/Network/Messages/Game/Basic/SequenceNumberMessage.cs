using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Basic
{
    public class SequenceNumberMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6317;

        public SequenceNumberMessage(ushort number)
        {
            Number = number;
        }

        public SequenceNumberMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort Number { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUShort(Number);
        }

        public override void Deserialize(IDataReader reader)
        {
            Number = reader.ReadUShort();
        }
    }
}