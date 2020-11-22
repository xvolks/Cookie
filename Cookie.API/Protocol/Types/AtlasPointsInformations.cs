using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class AtlasPointsInformations : NetworkType
    {
        public const ushort ProtocolId = 175;

        public override ushort TypeID => ProtocolId;

        public sbyte Type { get; set; }
        public List<MapCoordinatesExtended> Coords { get; set; }
        public AtlasPointsInformations() { }

        public AtlasPointsInformations( sbyte Type, List<MapCoordinatesExtended> Coords ){
            this.Type = Type;
            this.Coords = Coords;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Type);
			writer.WriteShort((short)Coords.Count);
			foreach (var x in Coords)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            Type = reader.ReadSByte();
            var CoordsCount = reader.ReadShort();
            Coords = new List<MapCoordinatesExtended>();
            for (var i = 0; i < CoordsCount; i++)
            {
                var objectToAdd = new MapCoordinatesExtended();
                objectToAdd.Deserialize(reader);
                Coords.Add(objectToAdd);
            }
        }
    }
}
