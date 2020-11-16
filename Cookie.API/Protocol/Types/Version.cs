using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class Version : NetworkType
    {
        public const ushort ProtocolId = 11;

        public override ushort TypeID => ProtocolId;

        public sbyte Major { get; set; }
        public sbyte Minor { get; set; }
        public sbyte Release { get; set; }
        public int Revision { get; set; }
        public sbyte Patch { get; set; }
        public sbyte BuildType { get; set; }
        public Version() { }

        public Version( sbyte Major, sbyte Minor, sbyte Release, int Revision, sbyte Patch, sbyte BuildType ){
            this.Major = Major;
            this.Minor = Minor;
            this.Release = Release;
            this.Revision = Revision;
            this.Patch = Patch;
            this.BuildType = BuildType;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Major);
            writer.WriteSByte(Minor);
            writer.WriteSByte(Release);
            writer.WriteInt(Revision);
            writer.WriteSByte(Patch);
            writer.WriteSByte(BuildType);
        }

        public override void Deserialize(IDataReader reader)
        {
            Major = reader.ReadSByte();
            Minor = reader.ReadSByte();
            Release = reader.ReadSByte();
            Revision = reader.ReadInt();
            Patch = reader.ReadSByte();
            BuildType = reader.ReadSByte();
        }
    }
}
