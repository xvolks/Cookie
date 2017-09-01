namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay
{
    using Types.Game.Context;
    using System.Collections.Generic;
    using Utils.IO;

    public class AtlasPointsInformations : NetworkType
    {
        public const ushort ProtocolId = 175;
        public override ushort TypeID => ProtocolId;
        public byte Type { get; set; }
        public List<MapCoordinatesExtended> Coords { get; set; }

        public AtlasPointsInformations(byte type, List<MapCoordinatesExtended> coords)
        {
            Type = type;
            Coords = coords;
        }

        public AtlasPointsInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Type);
            writer.WriteShort((short)Coords.Count);
            for (var coordsIndex = 0; coordsIndex < Coords.Count; coordsIndex++)
            {
                var objectToSend = Coords[coordsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            Type = reader.ReadByte();
            var coordsCount = reader.ReadUShort();
            Coords = new List<MapCoordinatesExtended>();
            for (var coordsIndex = 0; coordsIndex < coordsCount; coordsIndex++)
            {
                var objectToAdd = new MapCoordinatesExtended();
                objectToAdd.Deserialize(reader);
                Coords.Add(objectToAdd);
            }
        }

    }
}
