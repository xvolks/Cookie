using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class TeleportToBuddyOfferMessage : NetworkMessage
    {
        public const uint ProtocolId = 6287;
        public override uint MessageID { get { return ProtocolId; } }

        public short DungeonId = 0;
        public long BuddyId = 0;
        public int TimeLeft = 0;

        public TeleportToBuddyOfferMessage()
        {
        }

        public TeleportToBuddyOfferMessage(
            short dungeonId,
            long buddyId,
            int timeLeft
        )
        {
            DungeonId = dungeonId;
            BuddyId = buddyId;
            TimeLeft = timeLeft;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(DungeonId);
            writer.WriteVarLong(BuddyId);
            writer.WriteVarInt(TimeLeft);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            DungeonId = reader.ReadVarShort();
            BuddyId = reader.ReadVarLong();
            TimeLeft = reader.ReadVarInt();
        }
    }
}