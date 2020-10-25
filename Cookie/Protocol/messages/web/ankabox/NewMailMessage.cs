using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class NewMailMessage : MailStatusMessage
    {
        public new const uint ProtocolId = 6292;
        public override uint MessageID { get { return ProtocolId; } }

        public List<int> SendersAccountId;

        public NewMailMessage(): base()
        {
        }

        public NewMailMessage(
            short unread,
            short total,
            List<int> sendersAccountId
        ): base(
            unread,
            total
        )
        {
            SendersAccountId = sendersAccountId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)SendersAccountId.Count());
            foreach (var current in SendersAccountId)
            {
                writer.WriteInt(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            var countSendersAccountId = reader.ReadShort();
            SendersAccountId = new List<int>();
            for (short i = 0; i < countSendersAccountId; i++)
            {
                SendersAccountId.Add(reader.ReadInt());
            }
        }
    }
}