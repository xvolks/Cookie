namespace Cookie.API.Protocol.Network.Messages.Game.Tinsel
{
    using Utils.IO;

    public class TitleGainedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6364;
        public override ushort MessageID => ProtocolId;
        public ushort TitleId { get; set; }

        public TitleGainedMessage(ushort titleId)
        {
            TitleId = titleId;
        }

        public TitleGainedMessage() { }

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
