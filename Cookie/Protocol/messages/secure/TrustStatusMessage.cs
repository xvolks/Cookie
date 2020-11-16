using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class TrustStatusMessage : NetworkMessage
    {
        public const uint ProtocolId = 6267;
        public override uint MessageID { get { return ProtocolId; } }

        public bool Trusted = false;
        public bool Certified = false;

        public TrustStatusMessage()
        {
        }

        public TrustStatusMessage(
            bool trusted,
            bool certified
        )
        {
            Trusted = trusted;
            Certified = certified;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            byte box0 = 0;
            box0 = BooleanByteWrapper.SetFlag(box0, 1, Trusted);
            box0 = BooleanByteWrapper.SetFlag(box0, 2, Certified);
            writer.WriteByte(box0);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            byte box0 = reader.ReadByte();
            Trusted = BooleanByteWrapper.GetFlag(box0, 1);
            Certified = BooleanByteWrapper.GetFlag(box0, 2);
        }
    }
}