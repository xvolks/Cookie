using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class WrapperObjectErrorMessage : SymbioticObjectErrorMessage
    {
        public new const uint ProtocolId = 6529;
        public override uint MessageID { get { return ProtocolId; } }

        public WrapperObjectErrorMessage(): base()
        {
        }

        public WrapperObjectErrorMessage(
            byte reason,
            byte errorCode
        ): base(
            reason,
            errorCode
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