namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Fight
{
    using Utils.IO;

    public class GameRolePlayPlayerFightRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5731;
        public override ushort MessageID => ProtocolId;
        public ulong TargetId { get; set; }
        public short TargetCellId { get; set; }
        public bool Friendly { get; set; }

        public GameRolePlayPlayerFightRequestMessage(ulong targetId, short targetCellId, bool friendly)
        {
            TargetId = targetId;
            TargetCellId = targetCellId;
            Friendly = friendly;
        }

        public GameRolePlayPlayerFightRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(TargetId);
            writer.WriteShort(TargetCellId);
            writer.WriteBoolean(Friendly);
        }

        public override void Deserialize(IDataReader reader)
        {
            TargetId = reader.ReadVarUhLong();
            TargetCellId = reader.ReadShort();
            Friendly = reader.ReadBoolean();
        }

    }
}
