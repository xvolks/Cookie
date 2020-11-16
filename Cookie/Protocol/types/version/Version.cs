using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class Version : NetworkType
    {
        public const short ProtocolId = 11;
        public override short TypeId { get { return ProtocolId; } }

        public byte Major = 0;
        public byte Minor = 0;
        public byte Release = 0;
        public int Revision = 0;
        public byte Patch = 0;
        public byte BuildType = 0;

        public Version()
        {
        }

        public Version(
            byte major,
            byte minor,
            byte release,
            int revision,
            byte patch,
            byte buildType
        )
        {
            Major = major;
            Minor = minor;
            Release = release;
            Revision = revision;
            Patch = patch;
            BuildType = buildType;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(Major);
            writer.WriteByte(Minor);
            writer.WriteByte(Release);
            writer.WriteInt(Revision);
            writer.WriteByte(Patch);
            writer.WriteByte(BuildType);
        }

        public override void Deserialize(ICustomDataInput reader)
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