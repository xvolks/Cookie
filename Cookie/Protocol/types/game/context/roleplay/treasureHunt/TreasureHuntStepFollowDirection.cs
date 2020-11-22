using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class TreasureHuntStepFollowDirection : TreasureHuntStep
    {
        public new const short ProtocolId = 468;
        public override short TypeId { get { return ProtocolId; } }

        public byte Direction = 1;
        public short MapCount = 0;

        public TreasureHuntStepFollowDirection(): base()
        {
        }

        public TreasureHuntStepFollowDirection(
            byte direction,
            short mapCount
        ): base()
        {
            Direction = direction;
            MapCount = mapCount;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteByte(Direction);
            writer.WriteVarShort(MapCount);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Direction = reader.ReadByte();
            MapCount = reader.ReadVarShort();
        }
    }
}