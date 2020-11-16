using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class TreasureHuntStepFollowDirection : TreasureHuntStep
    {
        public new const ushort ProtocolId = 468;

        public override ushort TypeID => ProtocolId;

        public sbyte Direction { get; set; }
        public ushort MapCount { get; set; }
        public TreasureHuntStepFollowDirection() { }

        public TreasureHuntStepFollowDirection( sbyte Direction, ushort MapCount ){
            this.Direction = Direction;
            this.MapCount = MapCount;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(Direction);
            writer.WriteVarUhShort(MapCount);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Direction = reader.ReadSByte();
            MapCount = reader.ReadVarUhShort();
        }
    }
}
