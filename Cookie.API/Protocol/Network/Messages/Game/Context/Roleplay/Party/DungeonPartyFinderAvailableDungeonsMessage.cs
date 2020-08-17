using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    public class DungeonPartyFinderAvailableDungeonsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6242;

        public DungeonPartyFinderAvailableDungeonsMessage(List<ushort> dungeonIds)
        {
            DungeonIds = dungeonIds;
        }

        public DungeonPartyFinderAvailableDungeonsMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<ushort> DungeonIds { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) DungeonIds.Count);
            for (var dungeonIdsIndex = 0; dungeonIdsIndex < DungeonIds.Count; dungeonIdsIndex++)
                writer.WriteVarUhShort(DungeonIds[dungeonIdsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var dungeonIdsCount = reader.ReadUShort();
            DungeonIds = new List<ushort>();
            for (var dungeonIdsIndex = 0; dungeonIdsIndex < dungeonIdsCount; dungeonIdsIndex++)
                DungeonIds.Add(reader.ReadVarUhShort());
        }
    }
}