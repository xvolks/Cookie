using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class DocumentReadingBeginMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5675;

        public override ushort MessageID => ProtocolId;

        public ushort DocumentId { get; set; }
        public DocumentReadingBeginMessage() { }

        public DocumentReadingBeginMessage( ushort DocumentId ){
            this.DocumentId = DocumentId;
        }

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
