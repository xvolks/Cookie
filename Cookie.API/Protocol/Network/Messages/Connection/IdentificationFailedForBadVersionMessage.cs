namespace Cookie.API.Protocol.Network.Messages.Connection
{
    using Types.Version;
    using Utils.IO;

    public class IdentificationFailedForBadVersionMessage : IdentificationFailedMessage
    {
        public new const ushort ProtocolId = 21;
        public override ushort MessageID => ProtocolId;
        public Version RequiredVersion { get; set; }

        public IdentificationFailedForBadVersionMessage(Version requiredVersion)
        {
            RequiredVersion = requiredVersion;
        }

        public IdentificationFailedForBadVersionMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            RequiredVersion.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            RequiredVersion = new Version();
            RequiredVersion.Deserialize(reader);
        }

    }
}
