using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class MapRewardRateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6827;

        public override ushort MessageID => ProtocolId;

        public short MapRate { get; set; }
        public short SubAreaRate { get; set; }
        public short TotalRate { get; set; }
        public MapRewardRateMessage() { }

        public MapRewardRateMessage( short MapRate, short SubAreaRate, short TotalRate ){
            this.MapRate = MapRate;
            this.SubAreaRate = SubAreaRate;
            this.TotalRate = TotalRate;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarShort(MapRate);
            writer.WriteVarShort(SubAreaRate);
            writer.WriteVarShort(TotalRate);
        }

        public override void Deserialize(IDataReader reader)
        {
            MapRate = reader.ReadVarShort();
            SubAreaRate = reader.ReadVarShort();
            TotalRate = reader.ReadVarShort();
        }
    }
}
