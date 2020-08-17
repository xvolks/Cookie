using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.Party
{
    public class PartyMemberGeoPosition : NetworkType
    {
        public const ushort ProtocolId = 378;

        public PartyMemberGeoPosition(int memberId, short worldX, short worldY, int mapId, ushort subAreaId)
        {
            MemberId = memberId;
            WorldX = worldX;
            WorldY = worldY;
            MapId = mapId;
            SubAreaId = subAreaId;
        }

        public PartyMemberGeoPosition()
        {
        }

        public override ushort TypeID => ProtocolId;
        public int MemberId { get; set; }
        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public int MapId { get; set; }
        public ushort SubAreaId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(MemberId);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteInt(MapId);
            writer.WriteVarUhShort(SubAreaId);
        }

        public override void Deserialize(IDataReader reader)
        {
            MemberId = reader.ReadInt();
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            MapId = reader.ReadInt();
            SubAreaId = reader.ReadVarUhShort();
        }
    }
}