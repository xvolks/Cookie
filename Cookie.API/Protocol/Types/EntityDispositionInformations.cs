using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class EntityDispositionInformations : NetworkType
    {
        public const ushort ProtocolId = 60;

        public override ushort TypeID => ProtocolId;

        public short CellId { get; set; }
        public sbyte Direction { get; set; }
        public EntityDispositionInformations() { }

        public EntityDispositionInformations( short CellId, sbyte Direction ){
            this.CellId = CellId;
            this.Direction = Direction;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort(CellId);
            writer.WriteSByte(Direction);
        }

        public override void Deserialize(IDataReader reader)
        {
            CellId = reader.ReadShort();
            Direction = reader.ReadSByte();
        }
    }
}
