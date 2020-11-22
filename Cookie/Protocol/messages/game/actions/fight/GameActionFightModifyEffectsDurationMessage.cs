using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameActionFightModifyEffectsDurationMessage : AbstractGameActionMessage
    {
        public new const uint ProtocolId = 6304;
        public override uint MessageID { get { return ProtocolId; } }

        public double TargetId = 0;
        public short Delta = 0;

        public GameActionFightModifyEffectsDurationMessage(): base()
        {
        }

        public GameActionFightModifyEffectsDurationMessage(
            short actionId,
            double sourceId,
            double targetId,
            short delta
        ): base(
            actionId,
            sourceId
        )
        {
            TargetId = targetId;
            Delta = delta;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(TargetId);
            writer.WriteShort(Delta);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            TargetId = reader.ReadDouble();
            Delta = reader.ReadShort();
        }
    }
}