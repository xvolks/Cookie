namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Visual
{
    using Utils.IO;

    public class GameRolePlaySpellAnimMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6114;
        public override ushort MessageID => ProtocolId;
        public ulong CasterId { get; set; }
        public ushort TargetCellId { get; set; }
        public ushort SpellId { get; set; }
        public short SpellLevel { get; set; }

        public GameRolePlaySpellAnimMessage(ulong casterId, ushort targetCellId, ushort spellId, short spellLevel)
        {
            CasterId = casterId;
            TargetCellId = targetCellId;
            SpellId = spellId;
            SpellLevel = spellLevel;
        }

        public GameRolePlaySpellAnimMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(CasterId);
            writer.WriteVarUhShort(TargetCellId);
            writer.WriteVarUhShort(SpellId);
            writer.WriteShort(SpellLevel);
        }

        public override void Deserialize(IDataReader reader)
        {
            CasterId = reader.ReadVarUhLong();
            TargetCellId = reader.ReadVarUhShort();
            SpellId = reader.ReadVarUhShort();
            SpellLevel = reader.ReadShort();
        }

    }
}
