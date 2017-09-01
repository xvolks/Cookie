using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Npc
{
    public class NpcDialogQuestionMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5617;

        public NpcDialogQuestionMessage(uint messageId, List<string> dialogParams, List<uint> visibleReplies)
        {
            MessageId = messageId;
            DialogParams = dialogParams;
            VisibleReplies = visibleReplies;
        }

        public NpcDialogQuestionMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public uint MessageId { get; set; }
        public List<string> DialogParams { get; set; }
        public List<uint> VisibleReplies { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(MessageId);
            writer.WriteShort((short) DialogParams.Count);
            for (var dialogParamsIndex = 0; dialogParamsIndex < DialogParams.Count; dialogParamsIndex++)
                writer.WriteUTF(DialogParams[dialogParamsIndex]);
            writer.WriteShort((short) VisibleReplies.Count);
            for (var visibleRepliesIndex = 0; visibleRepliesIndex < VisibleReplies.Count; visibleRepliesIndex++)
                writer.WriteVarUhInt(VisibleReplies[visibleRepliesIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            MessageId = reader.ReadVarUhInt();
            var dialogParamsCount = reader.ReadUShort();
            DialogParams = new List<string>();
            for (var dialogParamsIndex = 0; dialogParamsIndex < dialogParamsCount; dialogParamsIndex++)
                DialogParams.Add(reader.ReadUTF());
            var visibleRepliesCount = reader.ReadUShort();
            VisibleReplies = new List<uint>();
            for (var visibleRepliesIndex = 0; visibleRepliesIndex < visibleRepliesCount; visibleRepliesIndex++)
                VisibleReplies.Add(reader.ReadVarUhInt());
        }
    }
}