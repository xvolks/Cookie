using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Connection.Register
{
    public class NicknameRefusedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5638;

        public NicknameRefusedMessage(byte reason)
        {
            Reason = reason;
        }

        public NicknameRefusedMessage()
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