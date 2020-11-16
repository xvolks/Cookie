using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class TreasureHuntShowLegendaryUIMessage : NetworkMessage
    {
        public const uint ProtocolId = 6498;
        public override uint MessageID { get { return ProtocolId; } }

        public List<short> AvailableLegendaryIds;

        public TreasureHuntShowLegendaryUIMessage()
        {
        }

        public TreasureHuntShowLegendaryUIMessage(
            List<short> availableLegendaryIds
        )
        {
            AvailableLegendaryIds = availableLegendaryIds;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)AvailableLegendaryIds.Count());
            foreach (var current in AvailableLegendaryIds)
            {
                writer.WriteVarShort(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countAvailableLegendaryIds = reader.ReadShort();
            AvailableLegendaryIds = new List<short>();
            for (short i = 0; i < countAvailableLegendaryIds; i++)
            {
                AvailableLegendaryIds.Add(reader.ReadVarShort());
            }
        }
    }
}