namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Document
{
    using Utils.IO;

    public class ComicReadingBeginMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6536;
        public override ushort MessageID => ProtocolId;
        public ushort ComicId { get; set; }

        public ComicReadingBeginMessage(ushort comicId)
        {
            ComicId = comicId;
        }

        public ComicReadingBeginMessage() { }

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
