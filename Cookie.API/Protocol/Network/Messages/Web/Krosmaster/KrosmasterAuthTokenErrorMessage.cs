using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Web.Krosmaster
{
    public class KrosmasterAuthTokenErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6345;

        public KrosmasterAuthTokenErrorMessage(byte reason)
        {
            Reason = reason;
        }

        public KrosmasterAuthTokenErrorMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte Reason { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Reason);
        }

        public override void Deserialize(IDataReader reader)
        {
            Reason = reader.ReadByte();
        }
    }
}