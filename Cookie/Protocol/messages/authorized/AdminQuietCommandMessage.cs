using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AdminQuietCommandMessage : AdminCommandMessage
    {
        public new const uint ProtocolId = 5662;
        public override uint MessageID { get { return ProtocolId; } }

        public AdminQuietCommandMessage(): base()
        {
        }

        public AdminQuietCommandMessage(
            string content
        ): base(
            content
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