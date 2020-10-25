using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using Version = Cookie.Protocol.Network.Types.Version;

namespace Cookie.Protocol.Network.Messages
{
    public class IdentificationFailedForBadVersionMessage : IdentificationFailedMessage
    {
        public new const uint ProtocolId = 21;
        public override uint MessageID { get { return ProtocolId; } }

        public Version RequiredVersion;

        public IdentificationFailedForBadVersionMessage(): base()
        {
        }

        public IdentificationFailedForBadVersionMessage(
            byte reason,
            Version requiredVersion
        ): base(
            reason
        )
        {
            RequiredVersion = requiredVersion;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            RequiredVersion.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            RequiredVersion = new Version();
            RequiredVersion.Deserialize(reader);
        }
    }
}