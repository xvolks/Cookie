using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class NpcDialogQuestionMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5617;

        public override ushort MessageID => ProtocolId;

        public uint MessageId { get; set; }
        public List<string> DialogParams { get; set; }
        public List<int> VisibleReplies { get; set; }
        public NpcDialogQuestionMessage() { }

        public NpcDialogQuestionMessage( uint MessageId, List<string> DialogParams, List<int> VisibleReplies ){
            this.MessageId = MessageId;
            this.DialogParams = DialogParams;
            this.VisibleReplies = VisibleReplies;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(MessageId);
			writer.WriteShort((short)DialogParams.Count);
			foreach (var x in DialogParams)
			{
				writer.WriteUTF(x);
			}
			writer.WriteShort((short)VisibleReplies.Count);
			foreach (var x in VisibleReplies)
			{
				writer.WriteVarInt(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            MessageId = reader.ReadVarUhInt();
            var DialogParamsCount = reader.ReadShort();
            DialogParams = new List<string>();
            for (var i = 0; i < DialogParamsCount; i++)
            {
                DialogParams.Add(reader.ReadUTF());
            }
            var VisibleRepliesCount = reader.ReadShort();
            VisibleReplies = new List<int>();
            for (var i = 0; i < VisibleRepliesCount; i++)
            {
                VisibleReplies.Add(reader.ReadVarInt());
            }
        }
    }
}
