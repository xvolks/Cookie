using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class VersionExtended : Version
    {
        public new const short ProtocolId = 393;
        public override short TypeId { get { return ProtocolId; } }

        public byte Install = 0;
        public byte Technology = 0;

        public VersionExtended(): base()
        {
        }

        public VersionExtended(
            byte major,
            byte minor,
            byte release,
            int revision,
            byte patch,
            byte buildType,
            byte install,
            byte technology
        ): base(
            major,
            minor,
            release,
            revision,
            patch,
            buildType
        )
        {
            Install = install;
            Technology = technology;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteByte(Install);
            writer.WriteByte(Technology);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Install = reader.ReadByte();
            Technology = reader.ReadByte();
        }
    }
}