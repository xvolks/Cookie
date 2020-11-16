using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class LivingObjectMessageRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6066;

        public override ushort MessageID => ProtocolId;

        public ushort MsgId { get; set; }
        public List<string> Parameters { get; set; }
        public uint LivingObject { get; set; }
        public LivingObjectMessageRequestMessage() { }

        public LivingObjectMessageRequestMessage( ushort MsgId, List<string> Parameters, uint LivingObject ){
            this.MsgId = MsgId;
            this.Parameters = Parameters;
            this.LivingObject = LivingObject;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(MsgId);
			writer.WriteShort((short)Parameters.Count);
			foreach (var x in Parameters)
			{
				writer.WriteUTF(x);
			}
            writer.WriteVarUhInt(LivingObject);
        }

        public override void Deserialize(IDataReader reader)
        {
            MsgId = reader.ReadVarUhShort();
            var ParametersCount = reader.ReadShort();
            Parameters = new List<string>();
            for (var i = 0; i < ParametersCount; i++)
            {
                Parameters.Add(reader.ReadUTF());
            }
            LivingObject = reader.ReadVarUhInt();
        }
    }
}
