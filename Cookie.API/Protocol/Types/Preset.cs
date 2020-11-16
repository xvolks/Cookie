using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class Preset : NetworkType
    {
        public const ushort ProtocolId = 355;

        public override ushort TypeID => ProtocolId;

        public short Id { get; set; }
        public Preset() { }

        public Preset( short Id ){
            this.Id = Id;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(Id);
        }

        public override void Deserialize(IDataReader reader)
        {
            Id = reader.ReadShort();
        }
    }
}
