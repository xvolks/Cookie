using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameActionFightTriggerEffectMessage : GameActionFightDispellEffectMessage
    {
        public new const uint ProtocolId = 6147;
        public override uint MessageID { get { return ProtocolId; } }

        public GameActionFightTriggerEffectMessage(): base()
        {
        }

        public GameActionFightTriggerEffectMessage(
            short actionId,
            double sourceId,
            double targetId,
            bool verboseCast,
            int boostUID
        ): base(
            actionId,
            sourceId,
            targetId,
            verboseCast,
            boostUID
        )
        {
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
        }
    }
}