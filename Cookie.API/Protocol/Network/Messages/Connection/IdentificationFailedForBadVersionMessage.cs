using Cookie.API.Protocol.Network.Types.Version;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Connection
{
    public class IdentificationFailedForBadVersionMessage : IdentificationFailedMessage
    {
        public new const ushort ProtocolId = 21;

        public IdentificationFailedForBadVersionMessage(Version requiredVersion)
        {
            RequiredVersion = requiredVersion;
        }

        public IdentificationFailedForBadVersionMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public Version RequiredVersion { get; set; }

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