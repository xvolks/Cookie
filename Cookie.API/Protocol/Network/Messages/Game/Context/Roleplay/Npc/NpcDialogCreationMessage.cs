using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Npc
{
    public class NpcDialogCreationMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5618;

        public NpcDialogCreationMessage(int mapId, int npcId)
        {
            MapId = mapId;
            NpcId = npcId;
        }

        public NpcDialogCreationMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public int MapId { get; set; }
        public int NpcId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(MapId);
            writer.WriteInt(NpcId);
        }

        public override void Deserialize(IDataReader reader)
        {
            MapId = reader.ReadInt();
            NpcId = reader.ReadInt();
        }
    }
}