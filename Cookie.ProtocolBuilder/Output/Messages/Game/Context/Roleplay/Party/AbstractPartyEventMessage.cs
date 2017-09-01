namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    using Utils.IO;

    public class AbstractPartyEventMessage : AbstractPartyMessage
    {
        public new const ushort ProtocolId = 6273;
        public override ushort MessageID => ProtocolId;

        public AbstractPartyEventMessage() { }

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
