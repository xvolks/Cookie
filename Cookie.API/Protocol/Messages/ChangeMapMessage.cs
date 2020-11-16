using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ChangeMapMessage : NetworkMessage
    {
        public const ushort ProtocolId = 221;

        public override ushort MessageID => ProtocolId;

        public double MapId { get; set; }
        public bool Autopilot { get; set; }
        public ChangeMapMessage() { }

        public ChangeMapMessage( double MapId, bool Autopilot ){
            this.MapId = MapId;
            this.Autopilot = Autopilot;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(MapId);
            writer.WriteBoolean(Autopilot);
        }

        public override void Deserialize(IDataReader reader)
        {
            MapId = reader.ReadDouble();
            Autopilot = reader.ReadBoolean();
        }
    }
}
