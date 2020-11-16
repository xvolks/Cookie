using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class TreasureHuntFlag : NetworkType
    {
        public const ushort ProtocolId = 473;

        public override ushort TypeID => ProtocolId;

        public double MapId { get; set; }
        public sbyte State { get; set; }
        public TreasureHuntFlag() { }

        public TreasureHuntFlag( double MapId, sbyte State ){
            this.MapId = MapId;
            this.State = State;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(MapId);
            writer.WriteSByte(State);
        }

        public override void Deserialize(IDataReader reader)
        {
            MapId = reader.ReadDouble();
            State = reader.ReadSByte();
        }
    }
}
