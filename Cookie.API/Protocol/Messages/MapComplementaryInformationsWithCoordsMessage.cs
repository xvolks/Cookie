using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class MapComplementaryInformationsWithCoordsMessage : MapComplementaryInformationsDataMessage
    {
        public new const ushort ProtocolId = 6268;

        public override ushort MessageID => ProtocolId;

        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public MapComplementaryInformationsWithCoordsMessage() { }

        public MapComplementaryInformationsWithCoordsMessage( short WorldX, short WorldY ){
            this.WorldX = WorldX;
            this.WorldY = WorldY;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
        }
    }
}
