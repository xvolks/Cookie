using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Dare
{
    public class DareErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6667;

        public DareErrorMessage(byte error)
        {
            Error = error;
        }

        public DareErrorMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte Error { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Error);
        }

        public override void Deserialize(IDataReader reader)
        {
            Error = reader.ReadByte();
        }
    }
}