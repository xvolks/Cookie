using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.TreasureHunt
{
    public class TreasureHuntStepFollowDirection : TreasureHuntStep
    {
        public new const ushort ProtocolId = 468;

        public TreasureHuntStepFollowDirection(byte direction, ushort mapCount)
        {
            Direction = direction;
            MapCount = mapCount;
        }

        public TreasureHuntStepFollowDirection()
        {
        }

        public override ushort TypeID => ProtocolId;
        public byte Direction { get; set; }
        public ushort MapCount { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(Direction);
            writer.WriteVarUhShort(MapCount);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Direction = reader.ReadByte();
            MapCount = reader.ReadVarUhShort();
        }
    }
}