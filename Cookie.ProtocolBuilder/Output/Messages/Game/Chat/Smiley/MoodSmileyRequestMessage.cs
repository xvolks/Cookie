namespace Cookie.API.Protocol.Network.Messages.Game.Chat.Smiley
{
    using Utils.IO;

    public class MoodSmileyRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6192;
        public override ushort MessageID => ProtocolId;
        public ushort SmileyId { get; set; }

        public MoodSmileyRequestMessage(ushort smileyId)
        {
            SmileyId = smileyId;
        }

        public MoodSmileyRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(SmileyId);
        }

        public override void Deserialize(IDataReader reader)
        {
            SmileyId = reader.ReadVarUhShort();
        }

    }
}
