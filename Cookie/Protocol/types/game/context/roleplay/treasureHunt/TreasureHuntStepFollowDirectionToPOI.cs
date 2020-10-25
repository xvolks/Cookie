using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class TreasureHuntStepFollowDirectionToPOI : TreasureHuntStep
    {
        public new const short ProtocolId = 461;
        public override short TypeId { get { return ProtocolId; } }

        public byte Direction = 1;
        public short PoiLabelId = 0;

        public TreasureHuntStepFollowDirectionToPOI(): base()
        {
        }

        public TreasureHuntStepFollowDirectionToPOI(
            byte direction,
            short poiLabelId
        ): base()
        {
            Direction = direction;
            PoiLabelId = poiLabelId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteByte(Direction);
            writer.WriteVarShort(PoiLabelId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Direction = reader.ReadByte();
            PoiLabelId = reader.ReadVarShort();
        }
    }
}