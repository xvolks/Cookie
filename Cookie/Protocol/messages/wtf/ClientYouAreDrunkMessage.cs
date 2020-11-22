using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ClientYouAreDrunkMessage : DebugInClientMessage
    {
        public new const uint ProtocolId = 6594;
        public override uint MessageID { get { return ProtocolId; } }

        public ClientYouAreDrunkMessage(): base()
        {
        }

        public ClientYouAreDrunkMessage(
            byte level,
            string message
        ): base(
            level,
            message
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