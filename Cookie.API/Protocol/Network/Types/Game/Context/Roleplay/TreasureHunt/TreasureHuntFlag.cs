using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.TreasureHunt
{
    public class TreasureHuntFlag : NetworkType
    {
        public const ushort ProtocolId = 473;

        public TreasureHuntFlag(int mapId, byte state)
        {
            MapId = mapId;
            State = state;
        }

        public TreasureHuntFlag()
        {
        }

        public override ushort TypeID => ProtocolId;
        public int MapId { get; set; }
        public byte State { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(MapId);
            writer.WriteByte(State);
        }

        public override void Deserialize(IDataReader reader)
        {
            MapId = reader.ReadInt();
            State = reader.ReadByte();
        }
    }
}