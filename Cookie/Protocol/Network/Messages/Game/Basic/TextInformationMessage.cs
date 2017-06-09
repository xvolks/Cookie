using Cookie.IO;
using System.Collections.Generic;

namespace Cookie.Protocol.Network.Messages.Game.Basic
{
    public class TextInformationMessage : NetworkMessage
    {
        public const uint ProtocolId = 780;
        public override uint MessageID { get { return ProtocolId; } }

        public byte MsgType;
        public ushort MsgId;
        public List<string> Parameters;

        public TextInformationMessage() { }

        public TextInformationMessage(byte msgType, ushort msgId, List<string> parameters)
        {
            MsgType = msgType;
            MsgId = msgId;
            Parameters = parameters;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(MsgType);
            writer.WriteVarUhShort(MsgId);
            writer.WriteShort((short)Parameters.Count);
            for (int i = 0; i < Parameters.Count; i++)
            {
                writer.WriteUTF(Parameters[i]);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            MsgType = reader.ReadByte();
            MsgId = reader.ReadVarUhShort();
            ushort length = reader.ReadUShort();
            Parameters = new List<string>();
            for (int i = 0; i < length; i++)
            {
                Parameters.Add(reader.ReadUTF());
            }
        }
    }
}
