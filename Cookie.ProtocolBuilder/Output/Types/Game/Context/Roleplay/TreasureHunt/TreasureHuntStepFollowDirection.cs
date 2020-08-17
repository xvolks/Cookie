namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.TreasureHunt
{
    using Utils.IO;

    public class TreasureHuntStepFollowDirection : TreasureHuntStep
    {
        public new const ushort ProtocolId = 468;
        public override ushort TypeID => ProtocolId;
        public byte Direction { get; set; }
        public ushort MapCount { get; set; }

        public TreasureHuntStepFollowDirection(byte direction, ushort mapCount)
        {
            Direction = direction;
            MapCount = mapCount;
        }

        public TreasureHuntStepFollowDirection() { }

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
