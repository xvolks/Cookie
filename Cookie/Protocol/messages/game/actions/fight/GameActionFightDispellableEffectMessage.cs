using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameActionFightDispellableEffectMessage : AbstractGameActionMessage
    {
        public new const uint ProtocolId = 6070;
        public override uint MessageID { get { return ProtocolId; } }

        public AbstractFightDispellableEffect Effect;

        public GameActionFightDispellableEffectMessage(): base()
        {
        }

        public GameActionFightDispellableEffectMessage(
            short actionId,
            double sourceId,
            AbstractFightDispellableEffect effect
        ): base(
            actionId,
            sourceId
        )
        {
            Effect = effect;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort(Effect.TypeId);
            Effect.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            var effectTypeId = reader.ReadShort();
            Effect = new AbstractFightDispellableEffect();
            Effect.Deserialize(reader);
        }
    }
}