using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Security
{
    public class CheckFileRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6154;

        public CheckFileRequestMessage(string filename, byte type)
        {
            Filename = filename;
            Type = type;
        }

        public CheckFileRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public string Filename { get; set; }
        public byte Type { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Filename);
            writer.WriteByte(Type);
        }

        public override void Deserialize(IDataReader reader)
        {
            Filename = reader.ReadUTF();
            Type = reader.ReadByte();
        }
    }
}