using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Basic
{
    public class TextInformationMessage : NetworkMessage
    {
        public const ushort ProtocolId = 780;

        public TextInformationMessage(byte msgType, ushort msgId, List<string> parameters)
        {
            MsgType = msgType;
            MsgId = msgId;
            Parameters = parameters;
        }

        public TextInformationMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte MsgType { get; set; }
        public ushort MsgId { get; set; }
        public List<string> Parameters { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(MsgType);
            writer.WriteVarUhShort(MsgId);
            writer.WriteShort((short) Parameters.Count);
            for (var parametersIndex = 0; parametersIndex < Parameters.Count; parametersIndex++)
                writer.WriteUTF(Parameters[parametersIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            MsgType = reader.ReadByte();
            MsgId = reader.ReadVarUhShort();
            var parametersCount = reader.ReadUShort();
            Parameters = new List<string>();
            for (var parametersIndex = 0; parametersIndex < parametersCount; parametersIndex++)
                Parameters.Add(reader.ReadUTF());
        }
    }
}