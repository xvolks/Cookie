using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameActionFightModifyEffectsDurationMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 6304;

        public override ushort MessageID => ProtocolId;

        public double TargetId { get; set; }
        public short Delta { get; set; }
        public GameActionFightModifyEffectsDurationMessage() { }

        public GameActionFightModifyEffectsDurationMessage( double TargetId, short Delta ){
            this.TargetId = TargetId;
            this.Delta = Delta;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(TargetId);
            writer.WriteShort(Delta);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            TargetId = reader.ReadDouble();
            Delta = reader.ReadShort();
        }
    }
}
