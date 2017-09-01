namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    using Utils.IO;

    public class DungeonPartyFinderListenRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6246;
        public override ushort MessageID => ProtocolId;
        public ushort DungeonId { get; set; }

        public DungeonPartyFinderListenRequestMessage(ushort dungeonId)
        {
            DungeonId = dungeonId;
        }

        public DungeonPartyFinderListenRequestMessage() { }

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
