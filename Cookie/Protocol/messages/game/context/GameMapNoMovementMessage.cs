using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameMapNoMovementMessage : NetworkMessage
    {
        public const uint ProtocolId = 954;
        public override uint MessageID { get { return ProtocolId; } }

        public short CellX = 0;
        public short CellY = 0;

        public GameMapNoMovementMessage()
        {
        }

        public GameMapNoMovementMessage(
            short cellX,
            short cellY
        )
        {
            CellX = cellX;
            CellY = cellY;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort(CellX);
            writer.WriteShort(CellY);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            CellX = reader.ReadShort();
            CellY = reader.ReadShort();
        }
    }
}