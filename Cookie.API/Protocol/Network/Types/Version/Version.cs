using System;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Version
{
    public class Version : NetworkType
    {
        public const short ProtocolId = 11;

        public Version()
        {
        }

        public Version(sbyte major, sbyte minor, sbyte release, int revision, sbyte patch, sbyte buildType)
        {
            Major = major;
            Minor = minor;
            Release = release;
            Revision = revision;
            Patch = patch;
            BuildType = buildType;
        }

        public override short TypeID => ProtocolId;

        public sbyte Major { get; set; }
        public sbyte Minor { get; set; }
        public sbyte Release { get; set; }
        public int Revision { get; set; }
        public sbyte Patch { get; set; }
        public sbyte BuildType { get; set; }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteSByte(Major);
            writer.WriteSByte(Minor);
            writer.WriteSByte(Release);
            writer.WriteInt(Revision);
            writer.WriteSByte(Patch);
            writer.WriteSByte(BuildType);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Major = reader.ReadSByte();
            if (Major < 0)
                throw new Exception("Forbidden value on Major = " + Major +
                                    ", it doesn't respect the following condition : major < 0");
            Minor = reader.ReadSByte();
            if (Minor < 0)
                throw new Exception("Forbidden value on Minor = " + Minor +
                                    ", it doesn't respect the following condition : minor < 0");
            Release = reader.ReadSByte();
            if (Release < 0)
                throw new Exception("Forbidden value on Release = " + Release +
                                    ", it doesn't respect the following condition : release < 0");
            Revision = reader.ReadInt();
            if (Revision < 0)
                throw new Exception("Forbidden value on Revision = " + Revision +
                                    ", it doesn't respect the following condition : revision < 0");
            Patch = reader.ReadSByte();
            if (Patch < 0)
                throw new Exception("Forbidden value on Patch = " + Patch +
                                    ", it doesn't respect the following condition : patch < 0");
            BuildType = reader.ReadSByte();
            if (BuildType < 0)
                throw new Exception("Forbidden value on BuildType = " + BuildType +
                                    ", it doesn't respect the following condition : buildType < 0");
        }
    }
}