namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Npc
{
    using Utils.IO;

    public class NpcDialogReplyMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5616;
        public override ushort MessageID => ProtocolId;
        public uint ReplyId { get; set; }

        public NpcDialogReplyMessage(uint replyId)
        {
            ReplyId = replyId;
        }

        public NpcDialogReplyMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(ReplyId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ReplyId = reader.ReadVarUhInt();
        }

    }
}
