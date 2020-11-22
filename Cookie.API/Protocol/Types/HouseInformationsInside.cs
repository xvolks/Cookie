using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class HouseInformationsInside : HouseInformations
    {
        public new const ushort ProtocolId = 218;

        public override ushort TypeID => ProtocolId;

        public HouseInstanceInformations HouseInfos { get; set; }
        public short WorldX { get; set; }
        public short WorldY { get; set; }
        public HouseInformationsInside() { }

        public HouseInformationsInside( HouseInstanceInformations HouseInfos, short WorldX, short WorldY ){
            this.HouseInfos = HouseInfos;
            this.WorldX = WorldX;
            this.WorldY = WorldY;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            HouseInfos.Serialize(writer);
            writer.WriteShort(WorldX);
            writer.WriteShort(WorldY);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            HouseInfos = ProtocolTypeManager.GetInstance(reader.ReadUShort());
            HouseInfos.Deserialize(reader);
            WorldX = reader.ReadShort();
            WorldY = reader.ReadShort();
        }
    }
}
