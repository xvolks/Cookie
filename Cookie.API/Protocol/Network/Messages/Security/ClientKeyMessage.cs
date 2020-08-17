using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Security
{
    public class ClientKeyMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5607;

        public ClientKeyMessage(string key)
        {
            Key = key;
        }

        public ClientKeyMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public string Key { get; set; }

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