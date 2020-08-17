namespace Cookie.API.Protocol.Network.Messages.Game.Alliance
{
    using Messages.Game.Social;
    using Utils.IO;

    public class AllianceMotdMessage : SocialNoticeMessage
    {
        public new const ushort ProtocolId = 6685;
        public override ushort MessageID => ProtocolId;

        public AllianceMotdMessage() { }

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
