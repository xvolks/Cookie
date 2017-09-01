using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Interactive.Meeting
{
    public class TeleportBuddiesMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6289;

        public TeleportBuddiesMessage(ushort dungeonId)
        {
            DungeonId = dungeonId;
        }

        public TeleportBuddiesMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort DungeonId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(DungeonId);
        }

        public override void Deserialize(IDataReader reader)
        {
            DungeonId = reader.ReadVarUhShort();
        }
    }
}