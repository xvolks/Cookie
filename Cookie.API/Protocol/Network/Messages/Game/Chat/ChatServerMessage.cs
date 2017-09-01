using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Chat
{
    public class ChatServerMessage : ChatAbstractServerMessage
    {
        public new const ushort ProtocolId = 881;

        public ChatServerMessage(double senderId, string senderName, int senderAccountId)
        {
            SenderId = senderId;
            SenderName = senderName;
            SenderAccountId = senderAccountId;
        }

        public ChatServerMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public double SenderId { get; set; }
        public string SenderName { get; set; }
        public int SenderAccountId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(SenderId);
            writer.WriteUTF(SenderName);
            writer.WriteInt(SenderAccountId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            SenderId = reader.ReadDouble();
            SenderName = reader.ReadUTF();
            SenderAccountId = reader.ReadInt();
        }
    }
}