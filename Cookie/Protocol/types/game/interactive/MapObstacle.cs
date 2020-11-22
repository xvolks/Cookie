using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class MapObstacle : NetworkType
    {
        public const short ProtocolId = 200;
        public override short TypeId { get { return ProtocolId; } }

        public short ObstacleCellId = 0;
        public byte State = 0;

        public MapObstacle()
        {
        }

        public MapObstacle(
            short obstacleCellId,
            byte state
        )
        {
            ObstacleCellId = obstacleCellId;
            State = state;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(ObstacleCellId);
            writer.WriteByte(State);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ObstacleCellId = reader.ReadVarShort();
            State = reader.ReadByte();
        }
    }
}