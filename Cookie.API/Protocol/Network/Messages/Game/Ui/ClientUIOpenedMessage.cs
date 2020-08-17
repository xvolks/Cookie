using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Ui
{
    public class ClientUIOpenedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6459;

        public ClientUIOpenedMessage(byte type)
        {
            Type = type;
        }

        public ClientUIOpenedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte Type { get; set; }

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