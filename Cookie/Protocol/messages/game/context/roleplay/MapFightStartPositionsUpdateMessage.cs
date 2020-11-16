using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class MapFightStartPositionsUpdateMessage : NetworkMessage
    {
        public const uint ProtocolId = 6716;
        public override uint MessageID { get { return ProtocolId; } }

        public double MapId = 0;
        public FightStartingPositions FightStartPositions;

        public MapFightStartPositionsUpdateMessage()
        {
        }

        public MapFightStartPositionsUpdateMessage(
            double mapId,
            FightStartingPositions fightStartPositions
        )
        {
            MapId = mapId;
            FightStartPositions = fightStartPositions;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteDouble(MapId);
            FightStartPositions.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            MapId = reader.ReadDouble();
            FightStartPositions = new FightStartingPositions();
            FightStartPositions.Deserialize(reader);
        }
    }
}