using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Server.Basic
{
    public class SystemMessageDisplayMessage : NetworkMessage
    {
        public const ushort ProtocolId = 189;

        public SystemMessageDisplayMessage(bool hangUp, ushort msgId, List<string> parameters)
        {
            HangUp = hangUp;
            MsgId = msgId;
            Parameters = parameters;
        }

        public SystemMessageDisplayMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool HangUp { get; set; }
        public ushort MsgId { get; set; }
        public List<string> Parameters { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(HangUp);
            writer.WriteVarUhShort(MsgId);
            writer.WriteShort((short) Parameters.Count);
            for (var parametersIndex = 0; parametersIndex < Parameters.Count; parametersIndex++)
                writer.WriteUTF(Parameters[parametersIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            HangUp = reader.ReadBoolean();
            MsgId = reader.ReadVarUhShort();
            var parametersCount = reader.ReadUShort();
            Parameters = new List<string>();
            for (var parametersIndex = 0; parametersIndex < parametersCount; parametersIndex++)
                Parameters.Add(reader.ReadUTF());
        }
    }
}