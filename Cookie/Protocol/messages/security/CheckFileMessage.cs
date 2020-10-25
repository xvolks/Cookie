using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class CheckFileMessage : NetworkMessage
    {
        public const uint ProtocolId = 6156;
        public override uint MessageID { get { return ProtocolId; } }

        public string FilenameHash;
        public byte Type = 0;
        public string Value;

        public CheckFileMessage()
        {
        }

        public CheckFileMessage(
            string filenameHash,
            byte type,
            string value
        )
        {
            FilenameHash = filenameHash;
            Type = type;
            Value = value;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteUTF(FilenameHash);
            writer.WriteByte(Type);
            writer.WriteUTF(Value);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            FilenameHash = reader.ReadUTF();
            Type = reader.ReadByte();
            Value = reader.ReadUTF();
        }
    }
}