namespace Cookie.API.Protocol.Network.Messages.Game.Interactive.Meeting
{
    using Utils.IO;

    public class TeleportBuddiesMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6289;
        public override ushort MessageID => ProtocolId;
        public ushort DungeonId { get; set; }

        public TeleportBuddiesMessage(ushort dungeonId)
        {
            DungeonId = dungeonId;
        }

        public TeleportBuddiesMessage() { }

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
