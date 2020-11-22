using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class AtlasPointsInformations : NetworkType
    {
        public const short ProtocolId = 175;
        public override short TypeId { get { return ProtocolId; } }

        public byte Type = 0;
        public List<MapCoordinatesExtended> Coords;

        public AtlasPointsInformations()
        {
        }

        public AtlasPointsInformations(
            byte type,
            List<MapCoordinatesExtended> coords
        )
        {
            Type = type;
            Coords = coords;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(Type);
            writer.WriteShort((short)Coords.Count());
            foreach (var current in Coords)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Type = reader.ReadByte();
            var countCoords = reader.ReadShort();
            Coords = new List<MapCoordinatesExtended>();
            for (short i = 0; i < countCoords; i++)
            {
                MapCoordinatesExtended type = new MapCoordinatesExtended();
                type.Deserialize(reader);
                Coords.Add(type);
            }
        }
    }
}