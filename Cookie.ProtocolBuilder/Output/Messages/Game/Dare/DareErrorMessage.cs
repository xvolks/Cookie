namespace Cookie.API.Protocol.Network.Messages.Game.Dare
{
    using Utils.IO;

    public class DareErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6667;
        public override ushort MessageID => ProtocolId;
        public byte Error { get; set; }

        public DareErrorMessage(byte error)
        {
            Error = error;
        }

        public DareErrorMessage() { }

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
