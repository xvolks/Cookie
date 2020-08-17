namespace Cookie.API.Protocol.Network.Messages.Game.Chat.Smiley
{
    using Utils.IO;

    public class ChatSmileyRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 800;
        public override ushort MessageID => ProtocolId;
        public ushort SmileyId { get; set; }

        public ChatSmileyRequestMessage(ushort smileyId)
        {
            SmileyId = smileyId;
        }

        public ChatSmileyRequestMessage() { }

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
