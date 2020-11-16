using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class DareCriteria : NetworkType
    {
        public const ushort ProtocolId = 501;

        public override ushort TypeID => ProtocolId;

        public sbyte Type { get; set; }
        public List<int> Params { get; set; }
        public DareCriteria() { }

        public DareCriteria( sbyte Type, List<int> Params ){
            this.Type = Type;
            this.Params = Params;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Type);
			writer.WriteShort((short)Params.Count);
			foreach (var x in Params)
			{
				writer.WriteInt(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            Type = reader.ReadSByte();
            var ParamsCount = reader.ReadShort();
            Params = new List<int>();
            for (var i = 0; i < ParamsCount; i++)
            {
                Params.Add(reader.ReadInt());
            }
        }
    }
}
