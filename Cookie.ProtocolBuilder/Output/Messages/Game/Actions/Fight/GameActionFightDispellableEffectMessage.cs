namespace Cookie.API.Protocol.Network.Messages.Game.Actions.Fight
{
    using Messages.Game.Actions;
    using Types.Game.Actions.Fight;
    using Utils.IO;

    public class GameActionFightDispellableEffectMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 6070;
        public override ushort MessageID => ProtocolId;
        public AbstractFightDispellableEffect Effect { get; set; }

        public GameActionFightDispellableEffectMessage(AbstractFightDispellableEffect effect)
        {
            Effect = effect;
        }

        public GameActionFightDispellableEffectMessage() { }

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
