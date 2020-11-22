using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class PrismSubareaEmptyInfo : NetworkType
    {
        public const short ProtocolId = 438;
        public override short TypeId { get { return ProtocolId; } }

        public short SubAreaId = 0;
        public int AllianceId = 0;

        public PrismSubareaEmptyInfo()
        {
        }

        public PrismSubareaEmptyInfo(
            short subAreaId,
            int allianceId
        )
        {
            SubAreaId = subAreaId;
            AllianceId = allianceId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(SubAreaId);
            writer.WriteVarInt(AllianceId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            SubAreaId = reader.ReadVarShort();
            AllianceId = reader.ReadVarInt();
        }
    }
}