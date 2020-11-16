using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class PaddockInformations : NetworkType
    {
        public const short ProtocolId = 132;
        public override short TypeId { get { return ProtocolId; } }

        public short MaxOutdoorMount = 0;
        public short MaxItems = 0;

        public PaddockInformations()
        {
        }

        public PaddockInformations(
            short maxOutdoorMount,
            short maxItems
        )
        {
            MaxOutdoorMount = maxOutdoorMount;
            MaxItems = maxItems;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(MaxOutdoorMount);
            writer.WriteVarShort(MaxItems);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            MaxOutdoorMount = reader.ReadVarShort();
            MaxItems = reader.ReadVarShort();
        }
    }
}