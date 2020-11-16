using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class TeleportToBuddyAnswerMessage : NetworkMessage
    {
        public const uint ProtocolId = 6293;
        public override uint MessageID { get { return ProtocolId; } }

        public short DungeonId = 0;
        public long BuddyId = 0;
        public bool Accept = false;

        public TeleportToBuddyAnswerMessage()
        {
        }

        public TeleportToBuddyAnswerMessage(
            short dungeonId,
            long buddyId,
            bool accept
        )
        {
            DungeonId = dungeonId;
            BuddyId = buddyId;
            Accept = accept;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(DungeonId);
            writer.WriteVarLong(BuddyId);
            writer.WriteBoolean(Accept);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            DungeonId = reader.ReadVarShort();
            BuddyId = reader.ReadVarLong();
            Accept = reader.ReadBoolean();
        }
    }
}