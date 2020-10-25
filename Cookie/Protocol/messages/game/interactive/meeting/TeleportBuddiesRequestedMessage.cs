using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class TeleportBuddiesRequestedMessage : NetworkMessage
    {
        public const uint ProtocolId = 6302;
        public override uint MessageID { get { return ProtocolId; } }

        public short DungeonId = 0;
        public long InviterId = 0;
        public List<long> InvalidBuddiesIds;

        public TeleportBuddiesRequestedMessage()
        {
        }

        public TeleportBuddiesRequestedMessage(
            short dungeonId,
            long inviterId,
            List<long> invalidBuddiesIds
        )
        {
            DungeonId = dungeonId;
            InviterId = inviterId;
            InvalidBuddiesIds = invalidBuddiesIds;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(DungeonId);
            writer.WriteVarLong(InviterId);
            writer.WriteShort((short)InvalidBuddiesIds.Count());
            foreach (var current in InvalidBuddiesIds)
            {
                writer.WriteVarLong(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            DungeonId = reader.ReadVarShort();
            InviterId = reader.ReadVarLong();
            var countInvalidBuddiesIds = reader.ReadShort();
            InvalidBuddiesIds = new List<long>();
            for (short i = 0; i < countInvalidBuddiesIds; i++)
            {
                InvalidBuddiesIds.Add(reader.ReadVarLong());
            }
        }
    }
}