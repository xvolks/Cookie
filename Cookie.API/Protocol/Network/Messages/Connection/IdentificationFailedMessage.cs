using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Connection
{
    public class IdentificationFailedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 20;

        public IdentificationFailedMessage(byte reason)
        {
            Reason = reason;
        }

        public IdentificationFailedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte Reason { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Reason);
        }

        public override void Deserialize(IDataReader reader)
        {
            Reason = reader.ReadByte();
        }
    }
}