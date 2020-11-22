using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class DungeonPartyFinderRoomContentUpdateMessage : NetworkMessage
    {
        public const uint ProtocolId = 6250;
        public override uint MessageID { get { return ProtocolId; } }

        public short DungeonId = 0;
        public List<DungeonPartyFinderPlayer> AddedPlayers;
        public List<long> RemovedPlayersIds;

        public DungeonPartyFinderRoomContentUpdateMessage()
        {
        }

        public DungeonPartyFinderRoomContentUpdateMessage(
            short dungeonId,
            List<DungeonPartyFinderPlayer> addedPlayers,
            List<long> removedPlayersIds
        )
        {
            DungeonId = dungeonId;
            AddedPlayers = addedPlayers;
            RemovedPlayersIds = removedPlayersIds;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(DungeonId);
            writer.WriteShort((short)AddedPlayers.Count());
            foreach (var current in AddedPlayers)
            {
                current.Serialize(writer);
            }
            writer.WriteShort((short)RemovedPlayersIds.Count());
            foreach (var current in RemovedPlayersIds)
            {
                writer.WriteVarLong(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            DungeonId = reader.ReadVarShort();
            var countAddedPlayers = reader.ReadShort();
            AddedPlayers = new List<DungeonPartyFinderPlayer>();
            for (short i = 0; i < countAddedPlayers; i++)
            {
                DungeonPartyFinderPlayer type = new DungeonPartyFinderPlayer();
                type.Deserialize(reader);
                AddedPlayers.Add(type);
            }
            var countRemovedPlayersIds = reader.ReadShort();
            RemovedPlayersIds = new List<long>();
            for (short i = 0; i < countRemovedPlayersIds; i++)
            {
                RemovedPlayersIds.Add(reader.ReadVarLong());
            }
        }
    }
}