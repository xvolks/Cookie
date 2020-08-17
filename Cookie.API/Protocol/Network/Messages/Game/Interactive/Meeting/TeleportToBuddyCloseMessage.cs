using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Interactive.Meeting
{
    public class TeleportToBuddyCloseMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6303;

        public TeleportToBuddyCloseMessage(ushort dungeonId, ulong buddyId)
        {
            DungeonId = dungeonId;
            BuddyId = buddyId;
        }

        public TeleportToBuddyCloseMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort DungeonId { get; set; }
        public ulong BuddyId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(DungeonId);
            writer.WriteVarUhLong(BuddyId);
        }

        public override void Deserialize(IDataReader reader)
        {
            DungeonId = reader.ReadVarUhShort();
            BuddyId = reader.ReadVarUhLong();
        }
    }
}