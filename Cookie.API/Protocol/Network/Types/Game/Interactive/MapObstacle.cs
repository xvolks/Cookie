using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Interactive
{
    public class MapObstacle : NetworkType
    {
        public const ushort ProtocolId = 200;

        public MapObstacle(ushort obstacleCellId, byte state)
        {
            ObstacleCellId = obstacleCellId;
            State = state;
        }

        public MapObstacle()
        {
        }

        public override ushort TypeID => ProtocolId;
        public ushort ObstacleCellId { get; set; }
        public byte State { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(ObstacleCellId);
            writer.WriteByte(State);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObstacleCellId = reader.ReadVarUhShort();
            State = reader.ReadByte();
        }
    }
}