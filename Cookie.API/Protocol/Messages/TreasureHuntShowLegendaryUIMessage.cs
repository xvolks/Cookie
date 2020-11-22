using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class TreasureHuntShowLegendaryUIMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6498;

        public override ushort MessageID => ProtocolId;

        public List<short> AvailableLegendaryIds { get; set; }
        public TreasureHuntShowLegendaryUIMessage() { }

        public TreasureHuntShowLegendaryUIMessage( List<short> AvailableLegendaryIds ){
            this.AvailableLegendaryIds = AvailableLegendaryIds;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)AvailableLegendaryIds.Count);
			foreach (var x in AvailableLegendaryIds)
			{
				writer.WriteVarShort(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var AvailableLegendaryIdsCount = reader.ReadShort();
            AvailableLegendaryIds = new List<short>();
            for (var i = 0; i < AvailableLegendaryIdsCount; i++)
            {
                AvailableLegendaryIds.Add(reader.ReadVarShort());
            }
        }
    }
}
