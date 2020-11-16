using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class IgnoredInformations : AbstractContactInformations
    {
        public new const short ProtocolId = 106;
        public override short TypeId { get { return ProtocolId; } }

        public IgnoredInformations(): base()
        {
        }

        public IgnoredInformations(
            int accountId,
            string accountName
        ): base(
            accountId,
            accountName
        )
        {
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
        }
    }
}