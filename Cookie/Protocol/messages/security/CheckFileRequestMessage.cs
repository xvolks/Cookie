using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class CheckFileRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6154;
        public override uint MessageID { get { return ProtocolId; } }

        public string Filename;
        public byte Type = 0;

        public CheckFileRequestMessage()
        {
        }

        public CheckFileRequestMessage(
            string filename,
            byte type
        )
        {
            Filename = filename;
            Type = type;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteUTF(Filename);
            writer.WriteByte(Type);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Filename = reader.ReadUTF();
            Type = reader.ReadByte();
        }
    }
}