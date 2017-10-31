namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    using System.Collections.Generic;
    using Utils.IO;

    public class DungeonPartyFinderRegisterSuccessMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6241;
        public override ushort MessageID => ProtocolId;
        public List<ushort> DungeonIds { get; set; }

        public DungeonPartyFinderRegisterSuccessMessage(List<ushort> dungeonIds)
        {
            DungeonIds = dungeonIds;
        }

        public DungeonPartyFinderRegisterSuccessMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)DungeonIds.Count);
            for (var dungeonIdsIndex = 0; dungeonIdsIndex < DungeonIds.Count; dungeonIdsIndex++)
            {
                writer.WriteVarUhShort(DungeonIds[dungeonIdsIndex]);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var dungeonIdsCount = reader.ReadUShort();
            DungeonIds = new List<ushort>();
            for (var dungeonIdsIndex = 0; dungeonIdsIndex < dungeonIdsCount; dungeonIdsIndex++)
            {
                DungeonIds.Add(reader.ReadVarUhShort());
            }
        }

    }
}
