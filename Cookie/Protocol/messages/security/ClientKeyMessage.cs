using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ClientKeyMessage : NetworkMessage
    {
        public const uint ProtocolId = 5607;
        public override uint MessageID { get { return ProtocolId; } }

        public string Key;

        public ClientKeyMessage()
        {
        }

        public ClientKeyMessage(
            string key
        )
        {
            Key = key;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteUTF(Key);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Key = reader.ReadUTF();
        }
    }
}