using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Prism
{
    public class PrismsListRegisterMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6441;

        public PrismsListRegisterMessage(byte listen)
        {
            Listen = listen;
        }

        public PrismsListRegisterMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte Listen { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Listen);
        }

        public override void Deserialize(IDataReader reader)
        {
            Listen = reader.ReadByte();
        }
    }
}