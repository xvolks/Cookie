using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay.Party;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    public class DungeonPartyFinderRoomContentUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6250;

        public DungeonPartyFinderRoomContentUpdateMessage(ushort dungeonId, List<DungeonPartyFinderPlayer> addedPlayers,
            List<ulong> removedPlayersIds)
        {
            DungeonId = dungeonId;
            AddedPlayers = addedPlayers;
            RemovedPlayersIds = removedPlayersIds;
        }

        public DungeonPartyFinderRoomContentUpdateMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort DungeonId { get; set; }
        public List<DungeonPartyFinderPlayer> AddedPlayers { get; set; }
        public List<ulong> RemovedPlayersIds { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(DungeonId);
            writer.WriteShort((short) AddedPlayers.Count);
            for (var addedPlayersIndex = 0; addedPlayersIndex < AddedPlayers.Count; addedPlayersIndex++)
            {
                var objectToSend = AddedPlayers[addedPlayersIndex];
                objectToSend.Serialize(writer);
            }
            writer.WriteShort((short) RemovedPlayersIds.Count);
            for (var removedPlayersIdsIndex = 0;
                removedPlayersIdsIndex < RemovedPlayersIds.Count;
                removedPlayersIdsIndex++)
                writer.WriteVarUhLong(RemovedPlayersIds[removedPlayersIdsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            DungeonId = reader.ReadVarUhShort();
            var addedPlayersCount = reader.ReadUShort();
            AddedPlayers = new List<DungeonPartyFinderPlayer>();
            for (var addedPlayersIndex = 0; addedPlayersIndex < addedPlayersCount; addedPlayersIndex++)
            {
                var objectToAdd = new DungeonPartyFinderPlayer();
                objectToAdd.Deserialize(reader);
                AddedPlayers.Add(objectToAdd);
            }
            var removedPlayersIdsCount = reader.ReadUShort();
            RemovedPlayersIds = new List<ulong>();
            for (var removedPlayersIdsIndex = 0;
                removedPlayersIdsIndex < removedPlayersIdsCount;
                removedPlayersIdsIndex++)
                RemovedPlayersIds.Add(reader.ReadVarUhLong());
        }
    }
}