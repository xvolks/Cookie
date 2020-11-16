using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class CompassUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5591;

        public override ushort MessageID => ProtocolId;

        public sbyte Type { get; set; }
        public MapCoordinates Coords { get; set; }
        public CompassUpdateMessage() { }

        public CompassUpdateMessage( sbyte Type, MapCoordinates Coords ){
            this.Type = Type;
            this.Coords = Coords;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Type);
            Coords.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            Type = reader.ReadSByte();
            Coords = ProtocolTypeManager.GetInstance(reader.ReadUShort());
            Coords.Deserialize(reader);
        }
    }
}
