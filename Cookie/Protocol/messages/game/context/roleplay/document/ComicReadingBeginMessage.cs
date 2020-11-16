using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ComicReadingBeginMessage : NetworkMessage
    {
        public const uint ProtocolId = 6536;
        public override uint MessageID { get { return ProtocolId; } }

        public short ComicId = 0;

        public ComicReadingBeginMessage()
        {
        }

        public ComicReadingBeginMessage(
            short comicId
        )
        {
            ComicId = comicId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(ComicId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ComicId = reader.ReadVarShort();
        }
    }
}