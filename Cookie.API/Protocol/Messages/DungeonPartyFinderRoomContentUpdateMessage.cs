using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class DungeonPartyFinderRoomContentUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6250;

        public override ushort MessageID => ProtocolId;

        public ushort DungeonId { get; set; }
        public List<DungeonPartyFinderPlayer> AddedPlayers { get; set; }
        public List<long> RemovedPlayersIds { get; set; }
        public DungeonPartyFinderRoomContentUpdateMessage() { }

        public DungeonPartyFinderRoomContentUpdateMessage( ushort DungeonId, List<DungeonPartyFinderPlayer> AddedPlayers, List<long> RemovedPlayersIds ){
            this.DungeonId = DungeonId;
            this.AddedPlayers = AddedPlayers;
            this.RemovedPlayersIds = RemovedPlayersIds;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(DungeonId);
			writer.WriteShort((short)AddedPlayers.Count);
			foreach (var x in AddedPlayers)
			{
				x.Serialize(writer);
			}
			writer.WriteShort((short)RemovedPlayersIds.Count);
			foreach (var x in RemovedPlayersIds)
			{
				writer.WriteVarLong(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            DungeonId = reader.ReadVarUhShort();
            var AddedPlayersCount = reader.ReadShort();
            AddedPlayers = new List<DungeonPartyFinderPlayer>();
            for (var i = 0; i < AddedPlayersCount; i++)
            {
                var objectToAdd = new DungeonPartyFinderPlayer();
                objectToAdd.Deserialize(reader);
                AddedPlayers.Add(objectToAdd);
            }
            var RemovedPlayersIdsCount = reader.ReadShort();
            RemovedPlayersIds = new List<long>();
            for (var i = 0; i < RemovedPlayersIdsCount; i++)
            {
                RemovedPlayersIds.Add(reader.ReadVarLong());
            }
        }
    }
}
