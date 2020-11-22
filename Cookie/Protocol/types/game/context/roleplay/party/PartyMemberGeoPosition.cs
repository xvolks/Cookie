using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class PartyMemberGeoPosition : NetworkType
    {
        public const short ProtocolId = 378;
        public override short TypeId { get { return ProtocolId; } }

        public int MemberId = 0;
        public short WorldX = 0;
        public short WorldY = 0;
        public double MapId = 0;
        public short SubAreaId = 0;

        public PartyMemberGeoPosition()
        {
        }

        public PartyMemberGeoPosition(
            int memberId,
            short worldX,
            short worldY,
            double mapId,
            short subAreaId
        )
        {
            MemberId = memberId;
            WorldX = worldX;
            WorldY = worldY;
            MapId = mapId;
            SubAreaId = subAreaId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(MemberId);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteDouble(MapId);
            writer.WriteVarShort(SubAreaId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            MemberId = reader.ReadInt();
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            MapId = reader.ReadDouble();
            SubAreaId = reader.ReadVarShort();
        }
    }
}