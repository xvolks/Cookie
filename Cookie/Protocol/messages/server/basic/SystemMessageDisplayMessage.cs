using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class SystemMessageDisplayMessage : NetworkMessage
    {
        public const uint ProtocolId = 189;
        public override uint MessageID { get { return ProtocolId; } }

        public bool HangUp = false;
        public short MsgId = 0;
        public List<string> Parameters;

        public SystemMessageDisplayMessage()
        {
        }

        public SystemMessageDisplayMessage(
            bool hangUp,
            short msgId,
            List<string> parameters
        )
        {
            HangUp = hangUp;
            MsgId = msgId;
            Parameters = parameters;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteBoolean(HangUp);
            writer.WriteVarShort(MsgId);
            writer.WriteShort((short)Parameters.Count());
            foreach (var current in Parameters)
            {
                writer.WriteUTF(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            HangUp = reader.ReadBoolean();
            MsgId = reader.ReadVarShort();
            var countParameters = reader.ReadShort();
            Parameters = new List<string>();
            for (short i = 0; i < countParameters; i++)
            {
                Parameters.Add(reader.ReadUTF());
            }
        }
    }
}