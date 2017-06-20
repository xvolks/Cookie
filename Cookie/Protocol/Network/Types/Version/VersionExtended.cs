using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types.Version
{
    public class VersionExtended : Version
    {
        public new const short ProtocolId = 393;
        public override short TypeID => ProtocolId;

        public sbyte Install { get; set; }
        public sbyte Technology { get; set; }

        public VersionExtended()
        {
        }

        public VersionExtended(sbyte major, sbyte minor, sbyte release, int revision, sbyte patch, sbyte buildType, sbyte install, sbyte technology)
         : base(major, minor, release, revision, patch, buildType)
        {
            this.Install = install;
            this.Technology = technology;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(Install);
            writer.WriteSByte(Technology);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Install = reader.ReadSByte();
            if (Install < 0)
                throw new Exception("Forbidden value on Install = " + Install + ", it doesn't respect the following condition : install < 0");
            Technology = reader.ReadSByte();
            if (Technology < 0)
                throw new Exception("Forbidden value on Technology = " + Technology + ", it doesn't respect the following condition : technology < 0");
        }

    }

}
