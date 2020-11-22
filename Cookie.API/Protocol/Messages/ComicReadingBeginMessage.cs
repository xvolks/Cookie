using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ComicReadingBeginMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6536;

        public override ushort MessageID => ProtocolId;

        public ushort ComicId { get; set; }
        public ComicReadingBeginMessage() { }

        public ComicReadingBeginMessage( ushort ComicId ){
            this.ComicId = ComicId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(ComicId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ComicId = reader.ReadVarUhShort();
        }
    }
}
