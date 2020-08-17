using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Look
{
    public class IndexedEntityLook : NetworkType
    {
        public const ushort ProtocolId = 405;

        public IndexedEntityLook(EntityLook look, byte index)
        {
            Look = look;
            Index = index;
        }

        public IndexedEntityLook()
        {
        }

        public override ushort TypeID => ProtocolId;
        public EntityLook Look { get; set; }
        public byte Index { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            Look.Serialize(writer);
            writer.WriteByte(Index);
        }

        public override void Deserialize(IDataReader reader)
        {
            Look = new EntityLook();
            Look.Deserialize(reader);
            Index = reader.ReadByte();
        }
    }
}