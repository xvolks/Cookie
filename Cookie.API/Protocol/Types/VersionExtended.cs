using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class VersionExtended : Version
    {
        public new const ushort ProtocolId = 393;

        public override ushort TypeID => ProtocolId;

        public sbyte Install { get; set; }
        public sbyte Technology { get; set; }
        public VersionExtended() { }

        public VersionExtended( sbyte Install, sbyte Technology ){
            this.Install = Install;
            this.Technology = Technology;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteSByte(Install);
            writer.WriteSByte(Technology);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Install = reader.ReadSByte();
            Technology = reader.ReadSByte();
        }
    }
}
