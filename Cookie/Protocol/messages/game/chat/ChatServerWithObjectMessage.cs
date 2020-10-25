using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class ChatServerWithObjectMessage : ChatServerMessage
    {
        public new const uint ProtocolId = 883;
        public override uint MessageID { get { return ProtocolId; } }

        public List<ObjectItem> Objects;

        public ChatServerWithObjectMessage(): base()
        {
        }

        public ChatServerWithObjectMessage(
            byte channel,
            string content,
            int timestamp,
            string fingerprint,
            double senderId,
            string senderName,
            string prefix,
            int senderAccountId,
            List<ObjectItem> objects
        ): base(
            channel,
            content,
            timestamp,
            fingerprint,
            senderId,
            senderName,
            prefix,
            senderAccountId
        )
        {
            Objects = objects;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)Objects.Count());
            foreach (var current in Objects)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            var countObjects = reader.ReadShort();
            Objects = new List<ObjectItem>();
            for (short i = 0; i < countObjects; i++)
            {
                ObjectItem type = new ObjectItem();
                type.Deserialize(reader);
                Objects.Add(type);
            }
        }
    }
}