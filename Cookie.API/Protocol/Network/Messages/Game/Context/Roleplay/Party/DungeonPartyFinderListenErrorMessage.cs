using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    public class DungeonPartyFinderListenErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6248;

        public DungeonPartyFinderListenErrorMessage(ushort dungeonId)
        {
            DungeonId = dungeonId;
        }

        public DungeonPartyFinderListenErrorMessage()
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