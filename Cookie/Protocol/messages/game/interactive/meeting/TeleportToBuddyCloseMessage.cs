using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class TeleportToBuddyCloseMessage : NetworkMessage
    {
        public const uint ProtocolId = 6303;
        public override uint MessageID { get { return ProtocolId; } }

        public short DungeonId = 0;
        public long BuddyId = 0;

        public TeleportToBuddyCloseMessage()
        {
        }

        public TeleportToBuddyCloseMessage(
            short dungeonId,
            long buddyId
        )
        {
            DungeonId = dungeonId;
            BuddyId = buddyId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(DungeonId);
            writer.WriteVarLong(BuddyId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            DungeonId = reader.ReadVarShort();
            BuddyId = reader.ReadVarLong();
        }
    }
}