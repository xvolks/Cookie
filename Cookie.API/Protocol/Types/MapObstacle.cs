using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class MapObstacle : NetworkType
    {
        public const ushort ProtocolId = 200;

        public override ushort TypeID => ProtocolId;

        public ushort ObstacleCellId { get; set; }
        public sbyte State { get; set; }
        public MapObstacle() { }

        public MapObstacle( ushort ObstacleCellId, sbyte State ){
            this.ObstacleCellId = ObstacleCellId;
            this.State = State;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(ObstacleCellId);
            writer.WriteSByte(State);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObstacleCellId = reader.ReadVarUhShort();
            State = reader.ReadSByte();
        }
    }
}
