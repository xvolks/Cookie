using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameActionFightSpellImmunityMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 6221;

        public override ushort MessageID => ProtocolId;

        public double TargetId { get; set; }
        public ushort SpellId { get; set; }
        public GameActionFightSpellImmunityMessage() { }

        public GameActionFightSpellImmunityMessage( double TargetId, ushort SpellId ){
            this.TargetId = TargetId;
            this.SpellId = SpellId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(TargetId);
            writer.WriteVarUhShort(SpellId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            TargetId = reader.ReadDouble();
            SpellId = reader.ReadVarUhShort();
        }
    }
}
