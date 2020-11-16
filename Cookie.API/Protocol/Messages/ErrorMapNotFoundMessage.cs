using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ErrorMapNotFoundMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6197;

        public override ushort MessageID => ProtocolId;

        public double MapId { get; set; }
        public ErrorMapNotFoundMessage() { }

        public ErrorMapNotFoundMessage( double MapId ){
            this.MapId = MapId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(MapId);
        }

        public override void Deserialize(IDataReader reader)
        {
            MapId = reader.ReadDouble();
        }
    }
}
