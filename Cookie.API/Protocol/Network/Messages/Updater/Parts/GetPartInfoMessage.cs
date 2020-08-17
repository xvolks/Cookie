using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Updater.Parts
{
    public class GetPartInfoMessage : NetworkMessage
    {
        public const ushort ProtocolId = 1506;

        public GetPartInfoMessage(string objectId)
        {
            ObjectId = objectId;
        }

        public GetPartInfoMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public string ObjectId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(ObjectId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadUTF();
        }
    }
}