using System.Collections.Generic;
using Cookie.API.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Basic
{
    public class TextInformationMessage : NetworkMessage
    {
        public const uint ProtocolId = 780;
        public ushort MsgId;

        public byte MsgType;
        public List<string> Parameters;

        public TextInformationMessage()
        {
        }

        public TextInformationMessage(byte msgType, ushort msgId, List<string> parameters)
        {
            MsgType = msgType;
            MsgId = msgId;
            Parameters = parameters;
        }

        public override uint MessageID => ProtocolId;

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(MsgType);
            writer.WriteVarUhShort(MsgId);
            writer.WriteShort((short) Parameters.Count);
            for (var i = 0; i < Parameters.Count; i++)
                writer.WriteUTF(Parameters[i]);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            MsgType = reader.ReadByte();
            MsgId = reader.ReadVarUhShort();
            var length = reader.ReadUShort();
            Parameters = new List<string>();
            for (var i = 0; i < length; i++)
                Parameters.Add(reader.ReadUTF());
        }
    }
}