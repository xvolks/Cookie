using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameActionFightSpellCooldownVariationMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 6219;

        public override ushort MessageID => ProtocolId;

        public double TargetId { get; set; }
        public ushort SpellId { get; set; }
        public short Value { get; set; }
        public GameActionFightSpellCooldownVariationMessage() { }

        public GameActionFightSpellCooldownVariationMessage( double TargetId, ushort SpellId, short Value ){
            this.TargetId = TargetId;
            this.SpellId = SpellId;
            this.Value = Value;
        }

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
