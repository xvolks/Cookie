using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameActionFightDeathMessage : AbstractGameActionMessage
    {
        public new const uint ProtocolId = 1099;
        public override uint MessageID { get { return ProtocolId; } }

        public double TargetId = 0;

        public GameActionFightDeathMessage(): base()
        {
        }

        public GameActionFightDeathMessage(
            short actionId,
            double sourceId,
            double targetId
        ): base(
            actionId,
            sourceId
        )
        {
            TargetId = targetId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(TargetId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            TargetId = reader.ReadDouble();
        }
    }
}