namespace Cookie.API.Protocol.Network.Messages.Security
{
    using Utils.IO;

    public class CheckFileMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6156;
        public override ushort MessageID => ProtocolId;
        public string FilenameHash { get; set; }
        public byte Type { get; set; }
        public string Value { get; set; }

        public CheckFileMessage(string filenameHash, byte type, string value)
        {
            FilenameHash = filenameHash;
            Type = type;
            Value = value;
        }

        public CheckFileMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(FilenameHash);
            writer.WriteByte(Type);
            writer.WriteUTF(Value);
        }

        public override void Deserialize(IDataReader reader)
        {
            FilenameHash = reader.ReadUTF();
            Type = reader.ReadByte();
            Value = reader.ReadUTF();
        }

    }
}
