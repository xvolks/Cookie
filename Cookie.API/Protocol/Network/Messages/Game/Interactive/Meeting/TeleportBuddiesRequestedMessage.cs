using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Interactive.Meeting
{
    public class TeleportBuddiesRequestedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6302;

        public TeleportBuddiesRequestedMessage(ushort dungeonId, ulong inviterId, List<ulong> invalidBuddiesIds)
        {
            DungeonId = dungeonId;
            InviterId = inviterId;
            InvalidBuddiesIds = invalidBuddiesIds;
        }

        public TeleportBuddiesRequestedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort DungeonId { get; set; }
        public ulong InviterId { get; set; }
        public List<ulong> InvalidBuddiesIds { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(DungeonId);
            writer.WriteVarUhLong(InviterId);
            writer.WriteShort((short) InvalidBuddiesIds.Count);
            for (var invalidBuddiesIdsIndex = 0;
                invalidBuddiesIdsIndex < InvalidBuddiesIds.Count;
                invalidBuddiesIdsIndex++)
                writer.WriteVarUhLong(InvalidBuddiesIds[invalidBuddiesIdsIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            DungeonId = reader.ReadVarUhShort();
            InviterId = reader.ReadVarUhLong();
            var invalidBuddiesIdsCount = reader.ReadUShort();
            InvalidBuddiesIds = new List<ulong>();
            for (var invalidBuddiesIdsIndex = 0;
                invalidBuddiesIdsIndex < invalidBuddiesIdsCount;
                invalidBuddiesIdsIndex++)
                InvalidBuddiesIds.Add(reader.ReadVarUhLong());
        }
    }
}