using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Chat.Smiley
{
    public class MoodSmileyRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6192;

        public MoodSmileyRequestMessage(ushort smileyId)
        {
            SmileyId = smileyId;
        }

        public MoodSmileyRequestMessage()
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