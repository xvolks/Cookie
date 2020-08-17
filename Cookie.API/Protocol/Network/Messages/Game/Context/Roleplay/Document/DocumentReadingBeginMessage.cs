using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Document
{
    public class DocumentReadingBeginMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5675;

        public DocumentReadingBeginMessage(ushort documentId)
        {
            DocumentId = documentId;
        }

        public DocumentReadingBeginMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort DocumentId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(DocumentId);
        }

        public override void Deserialize(IDataReader reader)
        {
            DocumentId = reader.ReadVarUhShort();
        }
    }
}