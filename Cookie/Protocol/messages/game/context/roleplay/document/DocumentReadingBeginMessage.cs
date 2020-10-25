using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class DocumentReadingBeginMessage : NetworkMessage
    {
        public const uint ProtocolId = 5675;
        public override uint MessageID { get { return ProtocolId; } }

        public short DocumentId = 0;

        public DocumentReadingBeginMessage()
        {
        }

        public DocumentReadingBeginMessage(
            short documentId
        )
        {
            DocumentId = documentId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(DocumentId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            DocumentId = reader.ReadVarShort();
        }
    }
}