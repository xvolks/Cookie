using Cookie.IO;


namespace Cookie.Protocol.Network.Messages.Secure
{
    class TrustStatusMessage : NetworkMessage
    {
        public const uint ProtocolId = 6267;
        public override uint MessageID { get { return ProtocolId; } }

        public bool Trusted;
        public bool Certified;

        public TrustStatusMessage() { }

        public TrustStatusMessage(bool trusted, bool certified)
        {
            Trusted = trusted;
            Certified = certified;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            byte flag = new byte();
            BooleanByteWrapper.SetFlag(0, flag, Trusted);
            BooleanByteWrapper.SetFlag(1, flag, Certified);
            writer.WriteByte(flag);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            byte flag = reader.ReadByte();
            Trusted = BooleanByteWrapper.GetFlag(flag, 0);
            Certified = BooleanByteWrapper.GetFlag(flag, 1);
        }
    }
}
