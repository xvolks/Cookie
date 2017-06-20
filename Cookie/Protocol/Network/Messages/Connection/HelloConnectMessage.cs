using Cookie.IO;

namespace Cookie.Protocol.Network.Messages.Connection
{
    public class HelloConnectMessage : NetworkMessage
    {
        public const uint ProtocolId = 3;
        public override uint MessageID => ProtocolId;

        public string Salt;
        public byte[] Key;

        public HelloConnectMessage() { }

        public HelloConnectMessage(string salt, byte[] key)
        {
            this.Salt = salt;
            this.Key = key;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteUTF(this.Salt);
            writer.WriteVarInt((int)(ushort)this.Key.Length);
            foreach (var @byte in this.Key)
                writer.WriteByte(@byte);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            this.Salt = reader.ReadUTF();
            var num = (ushort)reader.ReadVarInt();
            this.Key = new byte[(int)num];
            for (var index = 0; index < (int)num; ++index)
                this.Key[index] = reader.ReadByte();
        }
    }
}
