using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class TextInformationMessage : NetworkMessage
    {
        public const ushort ProtocolId = 780;

        public override ushort MessageID => ProtocolId;

        public sbyte MsgType { get; set; }
        public ushort MsgId { get; set; }
        public List<string> Parameters { get; set; }
        public TextInformationMessage() { }

        public TextInformationMessage( sbyte MsgType, ushort MsgId, List<string> Parameters ){
            this.MsgType = MsgType;
            this.MsgId = MsgId;
            this.Parameters = Parameters;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(MsgType);
            writer.WriteVarUhShort(MsgId);
			writer.WriteShort((short)Parameters.Count);
			foreach (var x in Parameters)
			{
				writer.WriteUTF(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            MsgType = reader.ReadSByte();
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
