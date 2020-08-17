using Cookie.API.Protocol.Network.Types.Game.Actions.Fight;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Actions.Fight
{
    public class GameActionFightDispellableEffectMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 6070;

        public GameActionFightDispellableEffectMessage(AbstractFightDispellableEffect effect)
        {
            Effect = effect;
        }

        public GameActionFightDispellableEffectMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public AbstractFightDispellableEffect Effect { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUShort(Effect.TypeID);
            Effect.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Effect = ProtocolTypeManager.GetInstance<AbstractFightDispellableEffect>(reader.ReadUShort());
            Effect.Deserialize(reader);
        }
    }
}