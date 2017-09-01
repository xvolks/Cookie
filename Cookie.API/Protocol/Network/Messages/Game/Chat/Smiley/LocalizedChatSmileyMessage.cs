using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Chat.Smiley
{
    public class LocalizedChatSmileyMessage : ChatSmileyMessage
    {
        public new const ushort ProtocolId = 6185;

        public LocalizedChatSmileyMessage(ushort cellId)
        {
            CellId = cellId;
        }

        public LocalizedChatSmileyMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort CellId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(CellId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            CellId = reader.ReadVarUhShort();
        }
    }
}