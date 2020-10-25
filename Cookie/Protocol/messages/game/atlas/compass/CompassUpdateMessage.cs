using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class CompassUpdateMessage : NetworkMessage
    {
        public const uint ProtocolId = 5591;
        public override uint MessageID { get { return ProtocolId; } }

        public byte Type = 0;
        public MapCoordinates Coords;

        public CompassUpdateMessage()
        {
        }

        public CompassUpdateMessage(
            byte type,
            MapCoordinates coords
        )
        {
            Type = type;
            Coords = coords;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(Type);
            writer.WriteShort(Coords.TypeId);
            Coords.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Type = reader.ReadByte();
            var coordsTypeId = reader.ReadShort();
            Coords = new MapCoordinates();
            Coords.Deserialize(reader);
        }
    }
}