using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class TeleportBuddiesRequestedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6302;

        public override ushort MessageID => ProtocolId;

        public ushort DungeonId { get; set; }
        public ulong InviterId { get; set; }
        public List<long> InvalidBuddiesIds { get; set; }
        public TeleportBuddiesRequestedMessage() { }

        public TeleportBuddiesRequestedMessage( ushort DungeonId, ulong InviterId, List<long> InvalidBuddiesIds ){
            this.DungeonId = DungeonId;
            this.InviterId = InviterId;
            this.InvalidBuddiesIds = InvalidBuddiesIds;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(DungeonId);
            writer.WriteVarUhLong(InviterId);
			writer.WriteShort((short)InvalidBuddiesIds.Count);
			foreach (var x in InvalidBuddiesIds)
			{
				writer.WriteVarLong(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            DungeonId = reader.ReadVarUhShort();
            InviterId = reader.ReadVarUhLong();
            var InvalidBuddiesIdsCount = reader.ReadShort();
            InvalidBuddiesIds = new List<long>();
            for (var i = 0; i < InvalidBuddiesIdsCount; i++)
            {
                InvalidBuddiesIds.Add(reader.ReadVarLong());
            }
        }
    }
}
