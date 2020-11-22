using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameActionFightSpellImmunityMessage : AbstractGameActionMessage
    {
        public new const uint ProtocolId = 6221;
        public override uint MessageID { get { return ProtocolId; } }

        public double TargetId = 0;
        public short SpellId = 0;

        public GameActionFightSpellImmunityMessage(): base()
        {
        }

        public GameActionFightSpellImmunityMessage(
            short actionId,
            double sourceId,
            double targetId,
            short spellId
        ): base(
            actionId,
            sourceId
        )
        {
            TargetId = targetId;
            SpellId = spellId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(TargetId);
            writer.WriteVarShort(SpellId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            TargetId = reader.ReadDouble();
            SpellId = reader.ReadVarShort();
        }
    }
}