using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class CurrentMapMessage : NetworkMessage
    {
        public const uint ProtocolId = 220;
        public override uint MessageID { get { return ProtocolId; } }

        public double MapId = 0;
        public string MapKey;

        public CurrentMapMessage()
        {
        }

        public CurrentMapMessage(
            double mapId,
            string mapKey
        )
        {
            MapId = mapId;
            MapKey = mapKey;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(MapId);
            writer.WriteUTF(MapKey);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            MapId = reader.ReadDouble();
            MapKey = reader.ReadUTF();
        }
    }
}