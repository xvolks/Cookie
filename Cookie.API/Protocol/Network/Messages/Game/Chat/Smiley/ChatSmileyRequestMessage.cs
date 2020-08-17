using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Chat.Smiley
{
    public class ChatSmileyRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 800;

        public ChatSmileyRequestMessage(ushort smileyId)
        {
            SmileyId = smileyId;
        }

        public ChatSmileyRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort SmileyId { get; set; }

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