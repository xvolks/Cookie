using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class HouseInformations : NetworkType
    {
        public const short ProtocolId = 111;
        public override short TypeId { get { return ProtocolId; } }

        public int HouseId = 0;
        public short ModelId = 0;

        public HouseInformations()
        {
        }

        public HouseInformations(
            int houseId,
            short modelId
        )
        {
            HouseId = houseId;
            ModelId = modelId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(HouseId);
            writer.WriteVarShort(ModelId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            HouseId = reader.ReadVarInt();
            ModelId = reader.ReadVarShort();
        }
    }
}