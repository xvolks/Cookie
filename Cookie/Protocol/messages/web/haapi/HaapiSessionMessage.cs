using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class HaapiSessionMessage : NetworkMessage
    {
        public const uint ProtocolId = 6769;
        public override uint MessageID { get { return ProtocolId; } }

        public string Key;
        public byte Type = 0;

        public HaapiSessionMessage()
        {
        }

        public HaapiSessionMessage(
            string key,
            byte type
        )
        {
            Key = key;
            Type = type;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteUTF(Key);
            writer.WriteByte(Type);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Key = reader.ReadUTF();
            Type = reader.ReadByte();
        }
    }
}