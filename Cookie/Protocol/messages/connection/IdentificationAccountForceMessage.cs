using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class IdentificationAccountForceMessage : IdentificationMessage
    {
        public new const uint ProtocolId = 6119;
        public override uint MessageID { get { return ProtocolId; } }

        public string ForcedAccountLogin;

        public IdentificationAccountForceMessage(): base()
        {
        }

        public IdentificationAccountForceMessage(
            bool autoconnect,
            bool useCertificate,
            bool useLoginToken,
            VersionExtended version,
            string lang,
            List<byte> credentials,
            short serverId,
            long sessionOptionalSalt,
            List<short> failedAttempts,
            string forcedAccountLogin
        ): base(
            autoconnect,
            useCertificate,
            useLoginToken,
            version,
            lang,
            lang,
            credentials.ToString(),
            serverId,
            sessionOptionalSalt,
            failedAttempts
        )
        {
            ForcedAccountLogin = forcedAccountLogin;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(ForcedAccountLogin);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            ForcedAccountLogin = reader.ReadUTF();
        }
    }
}