using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameActionFightTriggerGlyphTrapMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 5741;

        public override ushort MessageID => ProtocolId;

        public short MarkId { get; set; }
        public ushort MarkImpactCell { get; set; }
        public double TriggeringCharacterId { get; set; }
        public ushort TriggeredSpellId { get; set; }
        public GameActionFightTriggerGlyphTrapMessage() { }

        public GameActionFightTriggerGlyphTrapMessage( short MarkId, ushort MarkImpactCell, double TriggeringCharacterId, ushort TriggeredSpellId ){
            this.MarkId = MarkId;
            this.MarkImpactCell = MarkImpactCell;
            this.TriggeringCharacterId = TriggeringCharacterId;
            this.TriggeredSpellId = TriggeredSpellId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(MarkId);
            writer.WriteVarUhShort(MarkImpactCell);
            writer.WriteDouble(TriggeringCharacterId);
            writer.WriteVarUhShort(TriggeredSpellId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            MarkId = reader.ReadShort();
            MarkImpactCell = reader.ReadVarUhShort();
            TriggeringCharacterId = reader.ReadDouble();
            TriggeredSpellId = reader.ReadVarUhShort();
        }
    }
}
