using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class LivingObjectMessageRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6066;
        public override uint MessageID { get { return ProtocolId; } }

        public short MsgId = 0;
        public List<string> Parameters;
        public int LivingObject = 0;

        public LivingObjectMessageRequestMessage()
        {
        }

        public LivingObjectMessageRequestMessage(
            short msgId,
            List<string> parameters,
            int livingObject
        )
        {
            MsgId = msgId;
            Parameters = parameters;
            LivingObject = livingObject;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(MsgId);
            writer.WriteShort((short)Parameters.Count());
            foreach (var current in Parameters)
            {
                writer.WriteUTF(current);
            }
            writer.WriteVarInt(LivingObject);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            MsgId = reader.ReadVarShort();
            var countParameters = reader.ReadShort();
            Parameters = new List<string>();
            for (short i = 0; i < countParameters; i++)
            {
                Parameters.Add(reader.ReadUTF());
            }
            LivingObject = reader.ReadVarInt();
        }
    }
}