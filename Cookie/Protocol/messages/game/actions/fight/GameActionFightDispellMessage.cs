using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameActionFightDispellMessage : AbstractGameActionMessage
    {
        public new const uint ProtocolId = 5533;
        public override uint MessageID { get { return ProtocolId; } }

        public double TargetId = 0;
        public bool VerboseCast = false;

        public GameActionFightDispellMessage(): base()
        {
        }

        public GameActionFightDispellMessage(
            short actionId,
            double sourceId,
            double targetId,
            bool verboseCast
        ): base(
            actionId,
            sourceId
        )
        {
            TargetId = targetId;
            VerboseCast = verboseCast;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(TargetId);
            writer.WriteBoolean(VerboseCast);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            TargetId = reader.ReadDouble();
            VerboseCast = reader.ReadBoolean();
        }
    }
}