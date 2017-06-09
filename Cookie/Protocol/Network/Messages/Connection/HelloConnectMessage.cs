using Cookie.IO;

namespace Cookie.Protocol.Network.Messages.Connection
{
    public class HelloConnectMessage : NetworkMessage
    {
        public const uint ProtocolId = 3;
        public override uint MessageID { get { return ProtocolId; } }

        public string Salt;
        public sbyte[] Key;

        public HelloConnectMessage() { }

        public HelloConnectMessage(string salt, sbyte[] key)
        {
            this.Salt = salt;
            this.Key = key;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteUTF(this.Salt);
            writer.WriteVarInt((int)(ushort)this.Key.Length);
            foreach (sbyte @byte in this.Key)
                writer.WriteSByte(@byte);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            this.Salt = reader.ReadUTF();
            ushort num = (ushort)reader.ReadVarInt();
            this.Key = new sbyte[(int)num];
            for (int index = 0; index < (int)num; ++index)
                this.Key[index] = reader.ReadSByte();
        }
    }
}
