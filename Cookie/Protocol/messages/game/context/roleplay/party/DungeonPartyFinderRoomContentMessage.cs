using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class DungeonPartyFinderRoomContentMessage : NetworkMessage
    {
        public const uint ProtocolId = 6247;
        public override uint MessageID { get { return ProtocolId; } }

        public short DungeonId = 0;
        public List<DungeonPartyFinderPlayer> Players;

        public DungeonPartyFinderRoomContentMessage()
        {
        }

        public DungeonPartyFinderRoomContentMessage(
            short dungeonId,
            List<DungeonPartyFinderPlayer> players
        )
        {
            DungeonId = dungeonId;
            Players = players;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(DungeonId);
            writer.WriteShort((short)Players.Count());
            foreach (var current in Players)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            DungeonId = reader.ReadVarShort();
            var countPlayers = reader.ReadShort();
            Players = new List<DungeonPartyFinderPlayer>();
            for (short i = 0; i < countPlayers; i++)
            {
                DungeonPartyFinderPlayer type = new DungeonPartyFinderPlayer();
                type.Deserialize(reader);
                Players.Add(type);
            }
        }
    }
}