using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class Preset : NetworkType
    {
        public const short ProtocolId = 355;
        public override short TypeId { get { return ProtocolId; } }

        public short Id_ = 0;

        public Preset()
        {
        }

        public Preset(
            short id_
        )
        {
            Id_ = id_;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort(Id_);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Id_ = reader.ReadShort();
        }
    }
}