namespace Cookie.API.Protocol.Network.Messages.Game.Chat.Smiley
{
    using Utils.IO;

    public class ChatSmileyMessage : NetworkMessage
    {
        public const ushort ProtocolId = 801;
        public override ushort MessageID => ProtocolId;
        public double EntityId { get; set; }
        public ushort SmileyId { get; set; }
        public int AccountId { get; set; }

        public ChatSmileyMessage(double entityId, ushort smileyId, int accountId)
        {
            EntityId = entityId;
            SmileyId = smileyId;
            AccountId = accountId;
        }

        public ChatSmileyMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(EntityId);
            writer.WriteVarUhShort(SmileyId);
            writer.WriteInt(AccountId);
        }

        public override void Deserialize(IDataReader reader)
        {
            EntityId = reader.ReadDouble();
            SmileyId = reader.ReadVarUhShort();
            AccountId = reader.ReadInt();
        }

    }
}
