namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Npc
{
    using Utils.IO;

    public class NpcGenericActionRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5898;
        public override ushort MessageID => ProtocolId;
        public int NpcId { get; set; }
        public byte NpcActionId { get; set; }
        public double NpcMapId { get; set; }

        public NpcGenericActionRequestMessage(int npcId, byte npcActionId, double npcMapId)
        {
            NpcId = npcId;
            NpcActionId = npcActionId;
            NpcMapId = npcMapId;
        }

        public NpcGenericActionRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(NpcId);
            writer.WriteByte(NpcActionId);
            writer.WriteDouble(NpcMapId);
        }

        public override void Deserialize(IDataReader reader)
        {
            NpcId = reader.ReadInt();
            NpcActionId = reader.ReadByte();
            NpcMapId = reader.ReadDouble();
        }

    }
}
