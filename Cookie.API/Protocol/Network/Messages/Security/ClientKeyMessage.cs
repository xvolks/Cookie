using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Security
{
    public class ClientKeyMessage : NetworkMessage
    {
        public const uint ProtocolId = 5607;

        public ClientKeyMessage()
        {
        }

        public ClientKeyMessage(string key)
        {
            Key = key;
        }

        public override uint MessageID => ProtocolId;

        public string Key { get; set; }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteUTF(Key);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            _keyFunc(reader);
        }

        private void _keyFunc(ICustomDataInput Reader)
        {
            Key = Reader.ReadUTF();
        }
    }
}