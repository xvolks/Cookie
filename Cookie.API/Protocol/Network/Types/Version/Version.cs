using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Version
{
    public class Version : NetworkType
    {
        public const ushort ProtocolId = 11;

        public Version(byte major, byte minor, byte release, int revision, byte patch, byte buildType)
        {
            Major = major;
            Minor = minor;
            Release = release;
            Revision = revision;
            Patch = patch;
            BuildType = buildType;
        }

        public Version()
        {
        }

        public override ushort TypeID => ProtocolId;
        public byte Major { get; set; }
        public byte Minor { get; set; }
        public byte Release { get; set; }
        public int Revision { get; set; }
        public byte Patch { get; set; }
        public byte BuildType { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Major);
            writer.WriteByte(Minor);
            writer.WriteByte(Release);
            writer.WriteInt(Revision);
            writer.WriteByte(Patch);
            writer.WriteByte(BuildType);
        }

        public override void Deserialize(IDataReader reader)
        {
            Major = reader.ReadByte();
            Minor = reader.ReadByte();
            Release = reader.ReadByte();
            Revision = reader.ReadInt();
            Patch = reader.ReadByte();
            BuildType = reader.ReadByte();
        }
    }
}