namespace Cookie.API.Protocol.Network.Messages.Authorized
{
    using Utils.IO;

    public class AdminQuietCommandMessage : AdminCommandMessage
    {
        public new const ushort ProtocolId = 5662;
        public override ushort MessageID => ProtocolId;

        public AdminQuietCommandMessage() { }

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
