namespace Cookie.API.Protocol.Network.Types.Game.Context
{
    using Utils.IO;

    public class MapCoordinatesExtended : MapCoordinatesAndId
    {
        public new const ushort ProtocolId = 176;
        public override ushort TypeID => ProtocolId;
        public ushort SubAreaId { get; set; }

        public MapCoordinatesExtended(ushort subAreaId)
        {
            SubAreaId = subAreaId;
        }

        public MapCoordinatesExtended() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(SubAreaId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            SubAreaId = reader.ReadVarUhShort();
        }

    }
}
