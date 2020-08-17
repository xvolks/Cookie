using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context
{
    public class GameMapChangeOrientationRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 945;

        public GameMapChangeOrientationRequestMessage(byte direction)
        {
            Direction = direction;
        }

        public GameMapChangeOrientationRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte Direction { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Direction);
        }

        public override void Deserialize(IDataReader reader)
        {
            Direction = reader.ReadByte();
        }
    }
}