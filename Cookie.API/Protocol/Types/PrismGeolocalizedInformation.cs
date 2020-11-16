using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class PrismGeolocalizedInformation : PrismSubareaEmptyInfo
    {
        public new const ushort ProtocolId = 434;

        public override ushort TypeID => ProtocolId;

        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public double MapId { get; set; }
        public PrismInformation Prism { get; set; }
        public PrismGeolocalizedInformation() { }

        public PrismGeolocalizedInformation( short WorldX, short WorldY, double MapId, PrismInformation Prism ){
            this.WorldX = WorldX;
            this.WorldY = WorldY;
            this.MapId = MapId;
            this.Prism = Prism;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
            writer.WriteDouble(MapId);
            Prism.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
            MapId = reader.ReadDouble();
            Prism = ProtocolTypeManager.GetInstance(reader.ReadUShort());
            Prism.Deserialize(reader);
        }
    }
}
