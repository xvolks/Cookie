using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameActionFightTriggerGlyphTrapMessage : AbstractGameActionMessage
    {
        public new const uint ProtocolId = 5741;
        public override uint MessageID { get { return ProtocolId; } }

        public short MarkId = 0;
        public short MarkImpactCell = 0;
        public double TriggeringCharacterId = 0;
        public short TriggeredSpellId = 0;

        public GameActionFightTriggerGlyphTrapMessage(): base()
        {
        }

        public GameActionFightTriggerGlyphTrapMessage(
            short actionId,
            double sourceId,
            short markId,
            short markImpactCell,
            double triggeringCharacterId,
            short triggeredSpellId
        ): base(
            actionId,
            sourceId
        )
        {
            MarkId = markId;
            MarkImpactCell = markImpactCell;
            TriggeringCharacterId = triggeringCharacterId;
            TriggeredSpellId = triggeredSpellId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort(MarkId);
            writer.WriteVarShort(MarkImpactCell);
            writer.WriteDouble(TriggeringCharacterId);
            writer.WriteVarShort(TriggeredSpellId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            MarkId = reader.ReadShort();
            MarkImpactCell = reader.ReadVarShort();
            TriggeringCharacterId = reader.ReadDouble();
            TriggeredSpellId = reader.ReadVarShort();
        }
    }
}