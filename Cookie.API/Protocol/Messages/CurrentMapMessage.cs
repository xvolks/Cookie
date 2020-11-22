using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class CurrentMapMessage : NetworkMessage
    {
        public const ushort ProtocolId = 220;

        public override ushort MessageID => ProtocolId;

        public double MapId { get; set; }
        public string MapKey { get; set; }
        public CurrentMapMessage() { }

        public CurrentMapMessage( double MapId, string MapKey ){
            this.MapId = MapId;
            this.MapKey = MapKey;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(MapId);
            writer.WriteUTF(MapKey);
        }

        public override void Deserialize(IDataReader reader)
        {
            MapId = reader.ReadDouble();
            MapKey = reader.ReadUTF();
        }
    }
}
