using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameActionFightSpellCooldownVariationMessage : AbstractGameActionMessage
    {
        public new const uint ProtocolId = 6219;
        public override uint MessageID { get { return ProtocolId; } }

        public double TargetId = 0;
        public short SpellId = 0;
        public short Value = 0;

        public GameActionFightSpellCooldownVariationMessage(): base()
        {
        }

        public GameActionFightSpellCooldownVariationMessage(
            short actionId,
            double sourceId,
            double targetId,
            short spellId,
            short value
        ): base(
            actionId,
            sourceId
        )
        {
            TargetId = targetId;
            SpellId = spellId;
            Value = value;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(TargetId);
            writer.WriteVarShort(SpellId);
            writer.WriteVarShort(Value);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            TargetId = reader.ReadDouble();
            SpellId = reader.ReadVarShort();
            Value = reader.ReadVarShort();
        }
    }
}