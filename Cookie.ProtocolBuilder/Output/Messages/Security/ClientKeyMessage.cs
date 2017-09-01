namespace Cookie.API.Protocol.Network.Messages.Security
{
    using Utils.IO;

    public class ClientKeyMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5607;
        public override ushort MessageID => ProtocolId;
        public string Key { get; set; }

        public ClientKeyMessage(string key)
        {
            Key = key;
        }

        public ClientKeyMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Key);
        }

        public override void Deserialize(IDataReader reader)
        {
            Key = reader.ReadUTF();
        }

    }
}
