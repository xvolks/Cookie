using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class NpcDialogQuestionMessage : NetworkMessage
    {
        public const uint ProtocolId = 5617;
        public override uint MessageID { get { return ProtocolId; } }

        public int MessageId_ = 0;
        public List<string> DialogParams;
        public List<int> VisibleReplies;

        public NpcDialogQuestionMessage()
        {
        }

        public NpcDialogQuestionMessage(
            int messageId_,
            List<string> dialogParams,
            List<int> visibleReplies
        )
        {
            MessageId_ = messageId_;
            DialogParams = dialogParams;
            VisibleReplies = visibleReplies;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarInt(MessageId_);
            writer.WriteShort((short)DialogParams.Count());
            foreach (var current in DialogParams)
            {
                writer.WriteUTF(current);
            }
            writer.WriteShort((short)VisibleReplies.Count());
            foreach (var current in VisibleReplies)
            {
                writer.WriteVarInt(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            MessageId_ = reader.ReadVarInt();
            var countDialogParams = reader.ReadShort();
            DialogParams = new List<string>();
            for (short i = 0; i < countDialogParams; i++)
            {
                DialogParams.Add(reader.ReadUTF());
            }
            var countVisibleReplies = reader.ReadShort();
            VisibleReplies = new List<int>();
            for (short i = 0; i < countVisibleReplies; i++)
            {
                VisibleReplies.Add(reader.ReadVarInt());
            }
        }
    }
}