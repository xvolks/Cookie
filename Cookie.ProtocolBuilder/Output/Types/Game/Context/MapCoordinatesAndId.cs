namespace Cookie.API.Protocol.Network.Types.Game.Context
{
    using Utils.IO;

    public class MapCoordinatesAndId : MapCoordinates
    {
        public new const ushort ProtocolId = 392;
        public override ushort TypeID => ProtocolId;
        public int MapId { get; set; }

        public MapCoordinatesAndId(int mapId)
        {
            MapId = mapId;
        }

        public MapCoordinatesAndId() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(MapId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            MapId = reader.ReadInt();
        }

    }
}
