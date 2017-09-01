using Cookie.API.Protocol.Network.Types.Game.Context.Fight;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay
{
    public class MapFightStartPositionsUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6716;

        public MapFightStartPositionsUpdateMessage(int mapId, FightStartingPositions fightStartPositions)
        {
            MapId = mapId;
            FightStartPositions = fightStartPositions;
        }

        public MapFightStartPositionsUpdateMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public int MapId { get; set; }
        public FightStartingPositions FightStartPositions { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(MapId);
            FightStartPositions.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            MapId = reader.ReadInt();
            FightStartPositions = new FightStartingPositions();
            FightStartPositions.Deserialize(reader);
        }
    }
}