using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class HelloConnectMessage : NetworkMessage
    {
        public const uint ProtocolId = 3;
        public override uint MessageID { get { return ProtocolId; } }

        public string Salt;
        public List<byte> Key;

        public HelloConnectMessage()
        {
        }

        public HelloConnectMessage(
            string salt,
            List<byte> key
        )
        {
            Salt = salt;
            Key = key;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteUTF(Salt);
            writer.WriteVarInt((int)Key.Count());
            foreach (var current in Key)
            {
                writer.WriteByte(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Salt = reader.ReadUTF();
            var countKey = reader.ReadVarInt();
            Key = new List<byte>();
            for (int i = 0; i < countKey; i++)
            {
                Key.Add(reader.ReadByte());
            }
        }
    }
}