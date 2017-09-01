using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Web.Krosmaster
{
    public class KrosmasterInventoryErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6343;

        public KrosmasterInventoryErrorMessage(byte reason)
        {
            Reason = reason;
        }

        public KrosmasterInventoryErrorMessage()
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