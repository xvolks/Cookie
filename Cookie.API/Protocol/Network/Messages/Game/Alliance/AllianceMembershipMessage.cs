namespace Cookie.API.Protocol.Network.Messages.Game.Alliance
{
    using Types.Game.Context.Roleplay;
    using Utils.IO;

    public class AllianceMembershipMessage : AllianceJoinedMessage
    {
        public new const ushort ProtocolId = 6390;
        public override ushort MessageID => ProtocolId;

        public AllianceMembershipMessage() { }

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
