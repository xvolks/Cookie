using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ChangeMapMessage : NetworkMessage
    {
        public const uint ProtocolId = 221;
        public override uint MessageID { get { return ProtocolId; } }

        public double MapId = 0;
        public bool Autopilot = false;

        public ChangeMapMessage()
        {
        }

        public ChangeMapMessage(
            double mapId,
            bool autopilot
        )
        {
            MapId = mapId;
            Autopilot = autopilot;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(MapId);
            writer.WriteBoolean(Autopilot);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            MapId = reader.ReadDouble();
            Autopilot = reader.ReadBoolean();
        }
    }
}