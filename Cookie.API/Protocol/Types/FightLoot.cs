using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class FightLoot : NetworkType
    {
        public const ushort ProtocolId = 41;

        public override ushort TypeID => ProtocolId;

        public List<int> Objects { get; set; }
        public ulong Kamas { get; set; }
        public FightLoot() { }

        public FightLoot( List<int> Objects, ulong Kamas ){
            this.Objects = Objects;
            this.Kamas = Kamas;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Objects.Count);
			foreach (var x in Objects)
			{
				writer.WriteVarInt(x);
			}
            writer.WriteVarUhLong(Kamas);
        }

        public override void Deserialize(IDataReader reader)
        {
            var ObjectsCount = reader.ReadShort();
            Objects = new List<int>();
            for (var i = 0; i < ObjectsCount; i++)
            {
                Objects.Add(reader.ReadVarInt());
            }
            Kamas = reader.ReadVarUhLong();
        }
    }
}
