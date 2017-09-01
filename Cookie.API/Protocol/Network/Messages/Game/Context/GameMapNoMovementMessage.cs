using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context
{
    public class GameMapNoMovementMessage : NetworkMessage
    {
        public const ushort ProtocolId = 954;

        public GameMapNoMovementMessage(short cellX, short cellY)
        {
            CellX = cellX;
            CellY = cellY;
        }

        public GameMapNoMovementMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public short CellX { get; set; }
        public short CellY { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(CellX);
            writer.WriteShort(CellY);
        }

        public override void Deserialize(IDataReader reader)
        {
            CellX = reader.ReadShort();
            CellY = reader.ReadShort();
        }
    }
}