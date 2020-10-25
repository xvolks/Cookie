using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameMapChangeOrientationRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 945;
        public override uint MessageID { get { return ProtocolId; } }

        public byte Direction = 1;

        public GameMapChangeOrientationRequestMessage()
        {
        }

        public GameMapChangeOrientationRequestMessage(
            byte direction
        )
        {
            Direction = direction;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(Direction);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Direction = reader.ReadByte();
        }
    }
}