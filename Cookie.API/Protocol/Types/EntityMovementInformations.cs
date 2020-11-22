using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class EntityMovementInformations : NetworkType
    {
        public const ushort ProtocolId = 63;

        public override ushort TypeID => ProtocolId;

        public int Id { get; set; }
        public List<sbyte> Steps { get; set; }
        public EntityMovementInformations() { }

        public EntityMovementInformations( int Id, List<sbyte> Steps ){
            this.Id = Id;
            this.Steps = Steps;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(Id);
			writer.WriteShort((short)Steps.Count);
			foreach (var x in Steps)
			{
				writer.WriteSByte(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            Id = reader.ReadInt();
            var StepsCount = reader.ReadShort();
            Steps = new List<sbyte>();
            for (var i = 0; i < StepsCount; i++)
            {
                Steps.Add(reader.ReadSByte());
            }
        }
    }
}
