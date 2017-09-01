using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Web.Krosmaster
{
    public class KrosmasterTransferRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6349;

        public KrosmasterTransferRequestMessage(string uid)
        {
            Uid = uid;
        }

        public KrosmasterTransferRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public string Uid { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(Uid);
        }

        public override void Deserialize(IDataReader reader)
        {
            Uid = reader.ReadUTF();
        }
    }
}