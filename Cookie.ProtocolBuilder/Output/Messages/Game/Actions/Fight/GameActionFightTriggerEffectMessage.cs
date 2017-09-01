namespace Cookie.API.Protocol.Network.Messages.Game.Actions.Fight
{
    using Utils.IO;

    public class GameActionFightTriggerEffectMessage : GameActionFightDispellEffectMessage
    {
        public new const ushort ProtocolId = 6147;
        public override ushort MessageID => ProtocolId;

        public GameActionFightTriggerEffectMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
        }

    }
}
