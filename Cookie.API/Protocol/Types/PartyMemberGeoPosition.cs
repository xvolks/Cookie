using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class PartyMemberGeoPosition : NetworkType
    {
        public const ushort ProtocolId = 378;

        public override ushort TypeID => ProtocolId;

        public int MemberId { get; set; }
        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public double MapId { get; set; }
        public ushort SubAreaId { get; set; }
        public PartyMemberGeoPosition() { }

        public PartyMemberGeoPosition( int MemberId, short WorldX, short WorldY, double MapId, ushort SubAreaId ){
            this.MemberId = MemberId;
            this.WorldX = WorldX;
            this.WorldY = WorldY;
            this.MapId = MapId;
            this.SubAreaId = SubAreaId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(MemberId);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteDouble(MapId);
            writer.WriteVarUhShort(SubAreaId);
        }

        public override void Deserialize(IDataReader reader)
        {
            MemberId = reader.ReadInt();
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            MapId = reader.ReadDouble();
            SubAreaId = reader.ReadVarUhShort();
        }
    }
}
