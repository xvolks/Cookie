namespace Cookie.API.Protocol.Network.Messages.Game.Ui
{
    using Utils.IO;

    public class ClientUIOpenedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6459;
        public override ushort MessageID => ProtocolId;
        public byte Type { get; set; }

        public ClientUIOpenedMessage(byte type)
        {
            Type = type;
        }

        public ClientUIOpenedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Type);
        }

        public override void Deserialize(IDataReader reader)
        {
            Type = reader.ReadByte();
        }

    }
}
