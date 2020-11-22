using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class IndexedEntityLook : NetworkType
    {
        public const short ProtocolId = 405;
        public override short TypeId { get { return ProtocolId; } }

        public EntityLook Look;
        public byte Index = 0;

        public IndexedEntityLook()
        {
        }

        public IndexedEntityLook(
            EntityLook look,
            byte index
        )
        {
            Look = look;
            Index = index;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            Look.Serialize(writer);
            writer.WriteByte(Index);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Look = new EntityLook();
            Look.Deserialize(reader);
            Index = reader.ReadByte();
        }
    }
}