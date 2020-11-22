using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class EntityTalkMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6110;

        public override ushort MessageID => ProtocolId;

        public double EntityId { get; set; }
        public ushort TextId { get; set; }
        public List<string> Parameters { get; set; }
        public EntityTalkMessage() { }

        public EntityTalkMessage( double EntityId, ushort TextId, List<string> Parameters ){
            this.EntityId = EntityId;
            this.TextId = TextId;
            this.Parameters = Parameters;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(EntityId);
            writer.WriteVarUhShort(TextId);
			writer.WriteShort((short)Parameters.Count);
			foreach (var x in Parameters)
			{
				writer.WriteUTF(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            EntityId = reader.ReadDouble();
            TextId = reader.ReadVarUhShort();
            var ParametersCount = reader.ReadShort();
            Parameters = new List<string>();
            for (var i = 0; i < ParametersCount; i++)
            {
                Parameters.Add(reader.ReadUTF());
            }
        }
    }
}
