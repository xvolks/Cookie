using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class TextInformationMessage : NetworkMessage
    {
        public const uint ProtocolId = 780;
        public override uint MessageID { get { return ProtocolId; } }

        public byte MsgType = 0;
        public short MsgId = 0;
        public List<string> Parameters;

        public TextInformationMessage()
        {
        }

        public TextInformationMessage(
            byte msgType,
            short msgId,
            List<string> parameters
        )
        {
            MsgType = msgType;
            MsgId = msgId;
            Parameters = parameters;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(MsgType);
            writer.WriteVarShort(MsgId);
            writer.WriteShort((short)Parameters.Count());
            foreach (var current in Parameters)
            {
                writer.WriteUTF(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            MsgType = reader.ReadByte();
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