using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Connection
{
    public class HelloConnectMessage : NetworkMessage
    {
        public const uint ProtocolId = 3;
        public sbyte[] Key;

        public string Salt;

        public HelloConnectMessage()
        {
        }

        public HelloConnectMessage(string salt, sbyte[] key)
        {
            Salt = salt;
            Key = key;
        }

        public override uint MessageID => ProtocolId;

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Salt);
            writer.WriteVarInt((ushort) Key.Length);
            foreach (var @byte in Key)
                writer.WriteSByte(@byte);
        }

        public override void Deserialize(IDataReader reader)
        {
            Salt = reader.ReadUTF();
            var num = (ushort) reader.ReadVarInt();
            Key = new sbyte[num];
            for (var index = 0; index < num; ++index)
                Key[index] = reader.ReadSByte();
        }
    }
}