using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Secure
{
    public class TrustStatusMessage : NetworkMessage
    {
        public const uint ProtocolId = 6267;
        public bool Certified;

        public bool Trusted;

        public TrustStatusMessage()
        {
        }

        public TrustStatusMessage(bool trusted, bool certified)
        {
            Trusted = trusted;
            Certified = certified;
        }

        public override uint MessageID => ProtocolId;

        public override void Serialize(IDataWriter writer)
        {
            var flag = new byte();
            BooleanByteWrapper.SetFlag(0, flag, Trusted);
            BooleanByteWrapper.SetFlag(1, flag, Certified);
            writer.WriteByte(flag);
        }

        public override void Deserialize(IDataReader reader)
        {
            var flag = reader.ReadByte();
            Trusted = BooleanByteWrapper.GetFlag(flag, 0);
            Certified = BooleanByteWrapper.GetFlag(flag, 1);
        }
    }
}