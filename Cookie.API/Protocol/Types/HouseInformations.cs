using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class HouseInformations : NetworkType
    {
        public const ushort ProtocolId = 111;

        public override ushort TypeID => ProtocolId;

        public uint HouseId { get; set; }
        public ushort ModelId { get; set; }
        public HouseInformations() { }

        public HouseInformations( uint HouseId, ushort ModelId ){
            this.HouseId = HouseId;
            this.ModelId = ModelId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(HouseId);
            writer.WriteVarUhShort(ModelId);
        }

        public override void Deserialize(IDataReader reader)
        {
            HouseId = reader.ReadVarUhInt();
            ModelId = reader.ReadVarUhShort();
        }
    }
}
