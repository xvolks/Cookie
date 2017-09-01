using Cookie.API.Protocol.Network.Types.Game.Context;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Atlas.Compass
{
    public class CompassUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5591;

        public CompassUpdateMessage(byte type, MapCoordinates coords)
        {
            Type = type;
            Coords = coords;
        }

        public CompassUpdateMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte Type { get; set; }
        public MapCoordinates Coords { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Type);
            writer.WriteUShort(Coords.TypeID);
            Coords.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Type = reader.ReadByte();
            Coords = ProtocolTypeManager.GetInstance<MapCoordinates>(reader.ReadUShort());
            Coords.Deserialize(reader);
        }
    }
}