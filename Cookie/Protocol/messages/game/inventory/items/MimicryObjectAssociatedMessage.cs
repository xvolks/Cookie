using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class MimicryObjectAssociatedMessage : SymbioticObjectAssociatedMessage
    {
        public new const uint ProtocolId = 6462;
        public override uint MessageID { get { return ProtocolId; } }

        public MimicryObjectAssociatedMessage(): base()
        {
        }

        public MimicryObjectAssociatedMessage(
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