using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class IdentificationFailedForBadVersionMessage : IdentificationFailedMessage
    {
        public new const ushort ProtocolId = 21;

        public override ushort MessageID => ProtocolId;

        public Version RequiredVersion { get; set; }
        public IdentificationFailedForBadVersionMessage() { }

        public IdentificationFailedForBadVersionMessage( Version RequiredVersion ){
            this.RequiredVersion = RequiredVersion;
        }

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
