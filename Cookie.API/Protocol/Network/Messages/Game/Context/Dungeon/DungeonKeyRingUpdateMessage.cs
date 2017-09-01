using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Dungeon
{
    public class DungeonKeyRingUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6296;

        public DungeonKeyRingUpdateMessage(ushort dungeonId, bool available)
        {
            DungeonId = dungeonId;
            Available = available;
        }

        public DungeonKeyRingUpdateMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort DungeonId { get; set; }
        public bool Available { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(DungeonId);
            writer.WriteBoolean(Available);
        }

        public override void Deserialize(IDataReader reader)
        {
            DungeonId = reader.ReadVarUhShort();
            Available = reader.ReadBoolean();
        }
    }
}