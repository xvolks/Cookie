using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameActionFightKillMessage : AbstractGameActionMessage
    {
        public new const uint ProtocolId = 5571;
        public override uint MessageID { get { return ProtocolId; } }

        public double TargetId = 0;

        public GameActionFightKillMessage(): base()
        {
        }

        public GameActionFightKillMessage(
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