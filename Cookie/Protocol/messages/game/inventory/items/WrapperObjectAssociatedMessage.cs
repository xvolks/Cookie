using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class WrapperObjectAssociatedMessage : SymbioticObjectAssociatedMessage
    {
        public new const uint ProtocolId = 6523;
        public override uint MessageID { get { return ProtocolId; } }

        public WrapperObjectAssociatedMessage(): base()
        {
        }

        public WrapperObjectAssociatedMessage(
            int hostUID
        ): base(
            hostUID
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