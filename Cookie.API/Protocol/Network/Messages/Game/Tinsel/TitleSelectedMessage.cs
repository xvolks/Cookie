namespace Cookie.API.Protocol.Network.Messages.Game.Tinsel
{
    using Utils.IO;

    public class TitleSelectedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6366;
        public override ushort MessageID => ProtocolId;
        public ushort TitleId { get; set; }

        public TitleSelectedMessage(ushort titleId)
        {
            TitleId = titleId;
        }

        public TitleSelectedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(TitleId);
        }

        public override void Deserialize(IDataReader reader)
        {
            TitleId = reader.ReadVarUhShort();
        }

    }
}
