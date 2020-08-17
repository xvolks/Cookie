using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Npc
{
    public class NpcDialogReplyMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5616;

        public NpcDialogReplyMessage(uint replyId)
        {
            ReplyId = replyId;
        }

        public NpcDialogReplyMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public uint ReplyId { get; set; }

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