using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ZaapDestinationsMessage : TeleportDestinationsMessage
    {
        public new const ushort ProtocolId = 6830;

        public override ushort MessageID => ProtocolId;

        public double SpawnMapId { get; set; }
        public ZaapDestinationsMessage() { }

        public ZaapDestinationsMessage( double SpawnMapId ){
            this.SpawnMapId = SpawnMapId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(SpawnMapId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            SpawnMapId = reader.ReadDouble();
        }
    }
}
