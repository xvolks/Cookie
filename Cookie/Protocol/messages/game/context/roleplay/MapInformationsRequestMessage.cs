using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class MapInformationsRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 225;
        public override uint MessageID { get { return ProtocolId; } }

        public double MapId = 0;

        public MapInformationsRequestMessage()
        {
        }

        public MapInformationsRequestMessage(
            double mapId
        )
        {
            MapId = mapId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(MapId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            MapId = reader.ReadDouble();
        }
    }
}