namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.TreasureHunt
{
    using Utils.IO;

    public class TreasureHuntStepFollowDirectionToPOI : TreasureHuntStep
    {
        public new const ushort ProtocolId = 461;
        public override ushort TypeID => ProtocolId;
        public byte Direction { get; set; }
        public ushort PoiLabelId { get; set; }

        public TreasureHuntStepFollowDirectionToPOI(byte direction, ushort poiLabelId)
        {
            Direction = direction;
            PoiLabelId = poiLabelId;
        }

        public TreasureHuntStepFollowDirectionToPOI() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(Direction);
            writer.WriteVarUhShort(PoiLabelId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Direction = reader.ReadByte();
            PoiLabelId = reader.ReadVarUhShort();
        }

    }
}
