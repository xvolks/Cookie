using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class SystemMessageDisplayMessage : NetworkMessage
    {
        public const ushort ProtocolId = 189;

        public override ushort MessageID => ProtocolId;

        public bool HangUp { get; set; }
        public ushort MsgId { get; set; }
        public List<string> Parameters { get; set; }
        public SystemMessageDisplayMessage() { }

        public SystemMessageDisplayMessage( bool HangUp, ushort MsgId, List<string> Parameters ){
            this.HangUp = HangUp;
            this.MsgId = MsgId;
            this.Parameters = Parameters;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(HangUp);
            writer.WriteVarUhShort(MsgId);
			writer.WriteShort((short)Parameters.Count);
			foreach (var x in Parameters)
			{
				writer.WriteUTF(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            HangUp = reader.ReadBoolean();
            MsgId = reader.ReadVarUhShort();
            var ParametersCount = reader.ReadShort();
            Parameters = new List<string>();
            for (var i = 0; i < ParametersCount; i++)
            {
                Parameters.Add(reader.ReadUTF());
            }
        }
    }
}
