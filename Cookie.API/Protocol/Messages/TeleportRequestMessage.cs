using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class TeleportRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5961;

        public override ushort MessageID => ProtocolId;

        public sbyte SourceType { get; set; }
        public sbyte DestinationType { get; set; }
        public double MapId { get; set; }
        public TeleportRequestMessage() { }

        public TeleportRequestMessage( sbyte SourceType, sbyte DestinationType, double MapId ){
            this.SourceType = SourceType;
            this.DestinationType = DestinationType;
            this.MapId = MapId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(SourceType);
            writer.WriteSByte(DestinationType);
            writer.WriteDouble(MapId);
        }

        public override void Deserialize(IDataReader reader)
        {
            SourceType = reader.ReadSByte();
            DestinationType = reader.ReadSByte();
            MapId = reader.ReadDouble();
        }
    }
}
