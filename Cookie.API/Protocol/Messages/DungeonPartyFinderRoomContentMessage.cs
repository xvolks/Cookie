using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class DungeonPartyFinderRoomContentMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6247;

        public override ushort MessageID => ProtocolId;

        public ushort DungeonId { get; set; }
        public List<DungeonPartyFinderPlayer> Players { get; set; }
        public DungeonPartyFinderRoomContentMessage() { }

        public DungeonPartyFinderRoomContentMessage( ushort DungeonId, List<DungeonPartyFinderPlayer> Players ){
            this.DungeonId = DungeonId;
            this.Players = Players;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(DungeonId);
			writer.WriteShort((short)Players.Count);
			foreach (var x in Players)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            DungeonId = reader.ReadVarUhShort();
            var PlayersCount = reader.ReadShort();
            Players = new List<DungeonPartyFinderPlayer>();
            for (var i = 0; i < PlayersCount; i++)
            {
                var objectToAdd = new DungeonPartyFinderPlayer();
                objectToAdd.Deserialize(reader);
                Players.Add(objectToAdd);
            }
        }
    }
}
