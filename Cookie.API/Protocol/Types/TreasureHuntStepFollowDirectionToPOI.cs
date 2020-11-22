using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class TreasureHuntStepFollowDirectionToPOI : TreasureHuntStep
    {
        public new const ushort ProtocolId = 461;

        public override ushort TypeID => ProtocolId;

        public sbyte Direction { get; set; }
        public ushort PoiLabelId { get; set; }
        public TreasureHuntStepFollowDirectionToPOI() { }

        public TreasureHuntStepFollowDirectionToPOI( sbyte Direction, ushort PoiLabelId ){
            this.Direction = Direction;
            this.PoiLabelId = PoiLabelId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(Direction);
            writer.WriteVarUhShort(PoiLabelId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Direction = reader.ReadSByte();
            PoiLabelId = reader.ReadVarUhShort();
        }
    }
}
