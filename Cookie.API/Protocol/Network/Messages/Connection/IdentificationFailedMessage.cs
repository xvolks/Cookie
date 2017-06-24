using Cookie.API.IO;

namespace Cookie.API.Protocol.Network.Messages.Connection
{
    public class IdentificationFailedMessage : NetworkMessage
    {
        public const uint ProtocolId = 20;

        public uint Reason = 99;

        public IdentificationFailedMessage()
        {
        }

        public IdentificationFailedMessage(uint reason = 99)
        {
            Reason = reason;
        }

        public override uint MessageID => ProtocolId;

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte((byte) Reason);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Reason = reader.ReadByte();
        }
    }
}