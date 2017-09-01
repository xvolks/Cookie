using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay
{
    public class AtlasPointsInformations : NetworkType
    {
        public const ushort ProtocolId = 175;

        public AtlasPointsInformations(byte type, List<MapCoordinatesExtended> coords)
        {
            Type = type;
            Coords = coords;
        }

        public AtlasPointsInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public byte Type { get; set; }
        public List<MapCoordinatesExtended> Coords { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Type);
            writer.WriteShort((short) Coords.Count);
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