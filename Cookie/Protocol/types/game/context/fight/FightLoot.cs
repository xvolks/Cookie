using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class FightLoot : NetworkType
    {
        public const short ProtocolId = 41;
        public override short TypeId { get { return ProtocolId; } }

        public List<int> Objects;
        public long Kamas = 0;

        public FightLoot()
        {
        }

        public FightLoot(
            List<int> objects,
            long kamas
        )
        {
            Objects = objects;
            Kamas = kamas;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Objects.Count());
            foreach (var current in Objects)
            {
                writer.WriteVarInt(current);
            }
            writer.WriteVarLong(Kamas);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countObjects = reader.ReadShort();
            Objects = new List<int>();
            for (short i = 0; i < countObjects; i++)
            {
                Objects.Add(reader.ReadVarInt());
            }
            Kamas = reader.ReadVarLong();
        }
    }
}