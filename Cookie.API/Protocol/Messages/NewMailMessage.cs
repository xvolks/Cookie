using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class NewMailMessage : MailStatusMessage
    {
        public new const ushort ProtocolId = 6292;

        public override ushort MessageID => ProtocolId;

        public List<int> SendersAccountId { get; set; }
        public NewMailMessage() { }

        public NewMailMessage( List<int> SendersAccountId ){
            this.SendersAccountId = SendersAccountId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
			writer.WriteShort((short)SendersAccountId.Count);
			foreach (var x in SendersAccountId)
			{
				writer.WriteInt(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var SendersAccountIdCount = reader.ReadShort();
            SendersAccountId = new List<int>();
            for (var i = 0; i < SendersAccountIdCount; i++)
            {
                SendersAccountId.Add(reader.ReadInt());
            }
        }
    }
}
