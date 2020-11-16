using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class HouseLockFromInsideRequestMessage : LockableChangeCodeMessage
    {
        public new const uint ProtocolId = 5885;
        public override uint MessageID { get { return ProtocolId; } }

        public HouseLockFromInsideRequestMessage(): base()
        {
        }

        public HouseLockFromInsideRequestMessage(
            string code
        ): base(
            code
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