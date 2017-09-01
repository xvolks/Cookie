using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Actions.Fight
{
    public class GameActionFightSpellCooldownVariationMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 6219;

        public GameActionFightSpellCooldownVariationMessage(double targetId, ushort spellId, short value)
        {
            TargetId = targetId;
            SpellId = spellId;
            Value = value;
        }

        public GameActionFightSpellCooldownVariationMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public double TargetId { get; set; }
        public ushort SpellId { get; set; }
        public short Value { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(TargetId);
            writer.WriteVarUhShort(SpellId);
            writer.WriteVarShort(Value);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            TargetId = reader.ReadDouble();
            SpellId = reader.ReadVarUhShort();
            Value = reader.ReadVarShort();
        }
    }
}