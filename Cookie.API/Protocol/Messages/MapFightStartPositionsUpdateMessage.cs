using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class MapFightStartPositionsUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6716;

        public override ushort MessageID => ProtocolId;

        public double MapId { get; set; }
        public FightStartingPositions FightStartPositions { get; set; }
        public MapFightStartPositionsUpdateMessage() { }

        public MapFightStartPositionsUpdateMessage( double MapId, FightStartingPositions FightStartPositions ){
            this.MapId = MapId;
            this.FightStartPositions = FightStartPositions;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(MapId);
            FightStartPositions.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            MapId = reader.ReadDouble();
            FightStartPositions = new FightStartingPositions();
            FightStartPositions.Deserialize(reader);
        }
    }
}
