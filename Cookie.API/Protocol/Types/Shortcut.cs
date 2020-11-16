using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class Shortcut : NetworkType
    {
        public const ushort ProtocolId = 369;

        public override ushort TypeID => ProtocolId;

        public sbyte Slot { get; set; }
        public Shortcut() { }

        public Shortcut( sbyte Slot ){
            this.Slot = Slot;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Slot);
        }

        public override void Deserialize(IDataReader reader)
        {
            Slot = reader.ReadSByte();
        }
    }
}
