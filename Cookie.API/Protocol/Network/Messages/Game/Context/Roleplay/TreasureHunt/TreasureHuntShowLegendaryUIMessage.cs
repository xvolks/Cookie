using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.TreasureHunt
{
    public class TreasureHuntShowLegendaryUIMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6498;

        public TreasureHuntShowLegendaryUIMessage(List<ushort> availableLegendaryIds)
        {
            AvailableLegendaryIds = availableLegendaryIds;
        }

        public TreasureHuntShowLegendaryUIMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<ushort> AvailableLegendaryIds { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) AvailableLegendaryIds.Count);
            for (var availableLegendaryIdsIndex = 0;
                availableLegendaryIdsIndex < AvailableLegendaryIds.Count;
                availableLegendaryIdsIndex++)
                writer.WriteVarUhShort(AvailableLegendaryIds[availableLegendaryIdsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var availableLegendaryIdsCount = reader.ReadUShort();
            AvailableLegendaryIds = new List<ushort>();
            for (var availableLegendaryIdsIndex = 0;
                availableLegendaryIdsIndex < availableLegendaryIdsCount;
                availableLegendaryIdsIndex++)
                AvailableLegendaryIds.Add(reader.ReadVarUhShort());
        }
    }
}