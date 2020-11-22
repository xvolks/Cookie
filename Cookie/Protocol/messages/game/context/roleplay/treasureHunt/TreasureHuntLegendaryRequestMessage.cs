using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class TreasureHuntLegendaryRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6499;
        public override uint MessageID { get { return ProtocolId; } }

        public short LegendaryId = 0;

        public TreasureHuntLegendaryRequestMessage()
        {
        }

        public TreasureHuntLegendaryRequestMessage(
            short legendaryId
        )
        {
            LegendaryId = legendaryId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(LegendaryId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            LegendaryId = reader.ReadVarShort();
        }
    }
}